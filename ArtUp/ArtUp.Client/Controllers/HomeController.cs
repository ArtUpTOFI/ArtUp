using ArtUp.Client.Models;
using ArtUp.Client.Services;
using ArtUp.Client.Services.Instances;
using ArtUp.Client.Services.Interfaces;
using ArtUp.CLient.Services.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public HomeController()
        {
            _projectService = new ProjectService();
            _categoryService = new CategoryService();
            _giftService = new GiftService();
            _userDonationService = new UserDonationService();
            _userManagementService = new UserManagementService();
            _commentService = new CommentService();
            _searchService = new SearchService();
        }

        public ActionResult Index()
        {
            ViewBag.BestProjects = _projectService.GetProjectsOnMainPaige();
            ViewBag.BestProjectsBottom = _projectService.GetBySuccess(true).Take(3);
            ViewBag.NewProjects = _projectService.GetNewProjects().Take(3);
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
        public ActionResult Project(int id)
        {
            var project = _projectService.Get(id);
            ViewBag.Project = project;
            if (Request.IsAuthenticated)
            {
                ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
            }
            ViewBag.SimilarProjects = _projectService.GetByCategory(project.Category).Take(6);
            ViewBag.Gifts = _giftService.GetGifts(id);
            ViewBag.Donations = _userDonationService.GetDonations(id);
            ViewBag.Comments = _commentService.GetComments(id);
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Donate(int id)
        {
            ViewBag.Gifts = _giftService.GetGifts(id);
            ViewBag.Project = _projectService.Get(id);
            ViewBag.UserId = _userManagementService.GetCurrentUser(User.Identity.Name);
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Donate(UserDonationViewModel model)
        {
            _userDonationService.CreateDonation(model);
            return RedirectToAction("SuccessfulDonation");
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
            return PartialView();
        }

        [HttpPost]
        public ActionResult SearchResults(MainSearchViewModel model)
        {
            return RedirectToAction("SearchResults", "Home", new { @query = model.Query });
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
        public ActionResult CreateProject()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyProjects()
        {
            var donationProjects = _userDonationService.GetProjectsWithDonations(
                _userManagementService.GetCurrentUser(User.Identity.Name));
            ViewBag.MyDonationProjects = donationProjects.Any() ? donationProjects : null;
            return View();
        }
        //public ActionResult Comments()
        //{
        //    return PartialView();
        //}
    }
}