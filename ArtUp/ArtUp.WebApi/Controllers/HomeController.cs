using ArtUp.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtUp.WebApi.Controllers
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
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        //public ActionResult Project()
        //{
        //    return View();
        //}
        public ActionResult Project(int id)
        {
            ViewBag.Project = _projectService.Get(id);
            return View();
        }
    }
}
