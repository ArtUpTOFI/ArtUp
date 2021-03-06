﻿using ArtUp.Client.Models;
using ArtUp.Client.Services;
using ArtUp.Client.Services.Instances;
using ArtUp.Client.Services.Interfaces;
using ArtUp.CLient.Services.Instances;
using ArtUp.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtUp.BankMockServer.Services.Intarfaces;
using ArtUp.BankMockServer.Services.Concrete;
using System.IO;

namespace ArtUp.Client.Controllers
{
    public class HomeController : Controller
    {
        IProjectService _projectService;
        ICategoryService _categoryService;
        IGiftService _giftService;
        IUserDonationService _userDonationService;
        IUserManagementService _userManagementService;
        ICommentService _commentService;
        ISearchService _searchService;
        IUserApiService _bankApi;
        IPlatformDetailsService _platformDetailsService;

        public HomeController()
        {
            _projectService = new ProjectService();
            _categoryService = new CategoryService();
            _giftService = new GiftService();
            _userDonationService = new UserDonationService();
            _userManagementService = new UserManagementService();
            _commentService = new CommentService();
            _searchService = new SearchService();
            _bankApi = new UserApiService();
            _platformDetailsService = new PlatformDetailsService();
        }

        public ActionResult Index()
        {
            ViewBag.BestProjects = _projectService.GetProjectsOnMainPaige();
            ViewBag.BestProjectsBottom = _projectService.GetBySuccess(true).Take(3);
            ViewBag.NewProjects = _projectService.GetNewProjects().Take(3);
            ViewBag.AllProjects = _projectService.GetAllProjects().Where(p => p.ProjectState == ProjectState.Approved).Take(3);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Category(string category)
        {
            ViewBag.Category = category;
            ViewBag.Projects = _projectService.GetByCategory(category);
            return View();
        }

        [HttpGet]
        public ActionResult Filter(string filter)
        {
            ViewBag.Filter = filter;
            ViewBag.ProjectList = _projectService.GetByFilter(filter);
            return View();
        }

        [HttpGet]
        public ActionResult Project(int id)
        {
            var project = _projectService.Get(id);
            ViewBag.Project = project;
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
            }
            ViewBag.SimilarProjects = _projectService.GetByCategory(project.Category).Take(6).Where(p => p.Id != id);
            ViewBag.Gifts = _giftService.GetGifts(id);
            ViewBag.Donations = _userDonationService.GetDonations(id);
            ViewBag.Comments = _commentService.GetComments(id);
            if (project.ProjectState == ProjectState.PendingApproval)
                ViewBag.IsPending = true;
            else
                ViewBag.IsPending = false;
            if (project.ProjectState == ProjectState.Approved)
                ViewBag.IsApproved = true;
            else
                ViewBag.IsApproved = false;

            if (project.CreationDate.AddTicks(project.Duration) < DateTime.Now )
                ViewBag.IsEnbleButton = true;
            else
                ViewBag.IsEnbleButton = false;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Donate(int id)
        {
            ViewBag.Gifts = _giftService.GetGifts(id).Where(g => g.CurrentCount < g.AvailableCount);
            ViewBag.Project = _projectService.Get(id);
            ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Donate(UserDonationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var id = Convert.ToInt32(Request.RequestContext.RouteData.Values["id"]);
                ViewBag.Gifts = _giftService.GetGifts(id).Where(g => g.CurrentCount < g.AvailableCount);
                ViewBag.Project = _projectService.Get(id);
                ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
                return View();
            }
            if (model.Amount < 0)
            {
                ViewBag.Message = "Неверно введена сумма";
                return View("DonationError");
            }
            if (model.CardNumber.Count() != 16)
            {
                ViewBag.Message = "Некорректный номер карты";
                return View("DonationError");
            }
            if (model.CVV<100 || model.CVV>999 )
            {
                ViewBag.Message = "Некорректный код CVV2";
                return View("DonationError");
            }
            var name = model.CardHolder.Trim().Split();
            if (name.Count() != 2)
            {
                ViewBag.Message = "Некоректное имя";
                return View("DonationError");
            }
            var answer = _bankApi.CreateTransaction(model.CardNumber, "9999999999999", model.CVV, model.CardDate, name[0], name[1], (float)model.Amount);
            if (answer.Item1)
            {
                _userDonationService.CreateDonation(model);
                var currentProject = _projectService.Get(model.ProjectId);
                if (currentProject.CurrentMoney >= currentProject.RequiredMoney)
                {
                    currentProject.IsSuccessful = true;
                    _projectService.UpdateProject(currentProject);
                }
                return RedirectToAction("SuccessfulDonation");
            }
            else
            {
                ViewBag.Message = answer.Item2;
                return View("DonationError");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult LeaveComment(CommentViewModel model)
        {
            
            _commentService.CreateComment(model);
            return RedirectToAction("Project", "Home", new { @id = model.ProjectId});
        }

        public PartialViewResult Search()
        {
            return PartialView("_Search");
        }

        [HttpGet]
        public ViewResult WideSearch()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WideSearch(WideSearchViewModel model)
        {
            var searchResult = _searchService.WideSearch(model);
            return View("WideSearchResults", searchResult);
        }

        [HttpGet]
        public ActionResult SearchResults(string query)
        {
            ViewBag.Results = _searchService.SearchFromMain(query);
            return View();
        }

        [Authorize]
        public ActionResult SuccessfulDonation()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateProject()
        {
            ViewBag.Settings = _platformDetailsService.GetSettings();
            ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
            ViewBag.DateMessage = "";
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProject(ProjectViewModel model, HttpPostedFileBase uploadImage)
        {
            ViewBag.Message = "";
            if(model.DateOfBirth > DateTime.Now)
            {
                ViewBag.DateMessage = "Некорректная дата";
                ViewBag.Settings = _platformDetailsService.GetSettings();
                ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
                return View(model);
            }
            if (!ModelState.IsValid)
            {
                ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
                ViewBag.Settings = _platformDetailsService.GetSettings();
                return View();
            }
            if (uploadImage == null)
            {
                ViewBag.Message = "Обложка проекта не была добавлена";
                return View("DonationError");
            }

            if(!_bankApi.CheckAccount( model.AccountNumber))
            {
                ViewBag.Message = "BANK answer:Банковский счет указан неверно!";
                return View("DonationError");
            }

            string fileName = Path.GetFileName(uploadImage.FileName);
            uploadImage.SaveAs(Server.MapPath("~/Content/img/" + fileName));
            model.Avatar = fileName;

            var settings = _platformDetailsService.GetSettings();
            ViewBag.Settings = _platformDetailsService.GetSettings();

            _projectService.CreateProject(model);
            ViewBag.Message = "Отправка проекта на модерацию администратору прошла успешно!";            
            return View("DonationError");
        }

        [Authorize]
        public ActionResult MyProjects()
        {
            var userId = _userManagementService.GetCurrentUser(User.Identity.Name);
            var donationProjects = _userDonationService.GetProjectsWithDonations(userId);
            ViewBag.MyDonationProjects = donationProjects.Any() ? donationProjects : null;
            ViewBag.PendingProjects = _projectService.GetByState(ProjectState.PendingApproval, userId);
            ViewBag.ApprovedProjects = _projectService.GetByState(ProjectState.Approved, userId);
            ViewBag.RejectedProjects = _projectService.GetByState(ProjectState.Rejected, userId);
            return View();
        }

        public ViewResult Rules()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProject(int id)
        {
            ViewBag.Project = _projectService.Get(id);
            ViewBag.Settings = _platformDetailsService.GetSettings();
            ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditProject(ProjectViewModel model, HttpPostedFileBase uploadImage)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
                ViewBag.Settings = _platformDetailsService.GetSettings();
                return View();
            }
            if (uploadImage == null)
            {
                ViewBag.Message = "Обложка проекта не была добавлена";
                return View("DonationError");
            }

            if (!_bankApi.CheckAccount(model.AccountNumber))
            {
                ViewBag.Message = "BANK answer:Банковский счет указан неверно!";
                return View("DonationError");
            }

            string fileName = Path.GetFileName(uploadImage.FileName);
            uploadImage.SaveAs(Server.MapPath("~/Content/img/" + fileName));
            model.Avatar = fileName;

            var settings = _platformDetailsService.GetSettings();
            ViewBag.Settings = _platformDetailsService.GetSettings();

            var id = Convert.ToInt32(Request.RequestContext.RouteData.Values["id"]);
            _projectService.DeleteProject(id);

            _projectService.CreateProject(model);
            ViewBag.Message = "Отправка проекта на модерацию администратору прошла успешно!";
            return View("DonationError"); ;
        }
    }
}