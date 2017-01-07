using ArtUp.BankMockServer.Services.Concrete;
using ArtUp.BankMockServer.Services.Intarfaces;
using ArtUp.Client.Models;
using ArtUp.Client.Services;
using ArtUp.Client.Services.Instances;
using ArtUp.Client.Services.Interfaces;
using ArtUp.DataAccess.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtUp.Client.Controllers
{
    public class UserManagementController : Controller
    {
        IProjectService _projectService;
        IUserManagementService _userManagementService;
        IPlatformDetailsService _platformService;
        IUserDonationService _donationService;
        IUserApiService _bankApi;
        public UserManagementController()
        {
            _projectService = new ProjectService();
            _userManagementService = new UserManagementService();
            _platformService = new PlatformDetailsService();
            _donationService = new UserDonationService();
            _bankApi = new UserApiService();
        }

        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        [Authorize (Roles = "admin")]
        public ActionResult Users()
        {
            var res = _userManagementService.GetAllUsers();
            return View(res);
        }

        [Authorize (Roles = "admin")]
        public ActionResult GetUser(int id)
        {
            var User = _userManagementService.GetUser(id);

            return View(User);
        }

        [Authorize (Roles = "admin")]
        public ActionResult DeactiveUser(int id)
        {
            _userManagementService.DeactiveUser(id);

            return RedirectToAction("GetUser", "UserManagement", new { id = id });
        }

        [Authorize (Roles = "admin")]
        public ActionResult GetProjects()
        {
            var allProjects = _projectService.GetAllProjects();
            var projectsViewModel = new AdminProjectsViewModel
            {
                FinishedProject = allProjects.Where(p => p.CreationDate.AddTicks(p.Duration) < DateTime.Now && p.ProjectState == ProjectState.Approved && !p.WasPaid),
                ApprovedProjects = allProjects.Where(p => p.ProjectState == ProjectState.Approved).OrderByDescending(p=>p.IsSuccessful),
                PendingProjects = allProjects.Where(p => p.ProjectState == ProjectState.PendingApproval),
                RejectProjects = allProjects.Where(p => p.ProjectState == ProjectState.Rejected),
                InactiveProjects = allProjects.Where(p=>p.WasPaid)
            };
            ViewBag.allProjects = projectsViewModel;

            return View();
        }

        [Authorize (Roles = "admin")]
        public ActionResult ApproveProject(int id)
        {
            _projectService.ApproveProject(id);

            return RedirectToAction("Project", "Home", new { id = id });
        }

        [Authorize (Roles = "admin")]
        [HttpPost]
        public ActionResult RejectProject(int id)
        {
            var comment = Request.Form["Comment"];
            _projectService.RejectProject(id, comment);
            
            return RedirectToAction("Project", "Home", new { id = id });
        }

        [Authorize (Roles = "admin")]
        public ActionResult GetSettings()
        {
            var data = _platformService.GetSettings();

            return View(data);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult GetSettings(PlatformDetailsViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Неверные данные");
                return View();
            }
            if (model.IncomeTax < 0 || model.IncomeTax > 99)
            {
                ModelState.AddModelError("", "Неверно введен налог");
                return View();
            }
            if (model.PlatformComission < 0 || model.PlatformComission > 99)
            {
                ModelState.AddModelError("", "Неверно введен процент комиссии");
                return View();
            }
            if (model.MaxFreeAmount < 0)
            {
                ModelState.AddModelError("", "Неверно введена сумма");
                return View();
            }

            _platformService.SetSetting(model);
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult TransferMoney(int projectId)
        {
            decimal transferAmount, taxSum = 0;

            var currentProject = _projectService.Get(projectId);
            var settings = _platformService.GetSettings();
            var comissionPercents = settings.PlatformComission;
            var tax = settings.IncomeTax;
            var maxSum = settings.MaxFreeAmount;
            
            var comission = currentProject.CurrentMoney * (comissionPercents / 100);
            
            transferAmount = currentProject.CurrentMoney - comissionPercents;

            if (transferAmount > maxSum)
                taxSum = (transferAmount - maxSum) * tax / 100;

            transferAmount = transferAmount - taxSum;

            var answer = _bankApi.CreateTransaction("9999999999999", currentProject.AccountNumber, (float)transferAmount);
            var answer2 = _bankApi.CreateTransaction("9999999999999", "9999999999991", (float)comission);
            currentProject.WasPaid = true;
            _projectService.UpdateProject(currentProject);
            ViewBag.Answer = "Деньги переведены пользователю";

            ViewBag.Message = "Деньги переведены пользователю" + currentProject.Name + " " + currentProject.Surname;
            return RedirectToAction("Project", "Home", new { id = projectId });
        }

        [Authorize(Roles = "admin")]
        public ActionResult ReturnMoney(int id)
        {
            var currentProject = _projectService.Get(id);
            var res = _donationService.GetDetailsDonations(id);

            foreach(var d in res)
            {
                var message = _bankApi.CardTransaction("9999999999999", d.CardNumber, (float)d.Amount);
            }
            currentProject.WasPaid = true;
            currentProject.CurrentMoney = 0;
            _projectService.UpdateProject(currentProject);

            ViewBag.Message = "Деньги возвращены пользователям. Вернули " + currentProject.CurrentMoney.ToString() + "BYN";
            return RedirectToAction("Project", "Home", new { id = id });
        }
    }
}