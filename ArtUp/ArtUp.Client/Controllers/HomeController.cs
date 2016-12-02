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

        public HomeController()
        {
            _projectService = new ProjectService();
            _categoryService = new CategoryService();
            _giftService = new GiftService();
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
            ViewBag.SimilarProjects = _projectService.GetByCategory(project.Category).Take(6);
            ViewBag.Gifts = _giftService.GetGifts(id);
            return View();
        }

        [HttpGet]
        public ActionResult Donate(int id)
        {
            ViewBag.Gifts = _giftService.GetGifts(id);
            return View();
        }
        //public ActionResult Comments()
        //{
        //    return PartialView();
        //}
    }
}