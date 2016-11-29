using ArtUp.Client.Services;
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

        public HomeController()
        {
            _projectService = new ProjectService();
        }

        public ActionResult Index()
        {
            ViewBag.BestProjects = _projectService.GetProjectsOnMainPaige();
            ViewBag.BestProjectsBottom = _projectService.GetBySuccess(true).Take(3);
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
    }
}