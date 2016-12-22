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
        public UserManagementController()
        {
            _projectService = new ProjectService();
            _userManagementService = new UserManagementService();
            _platformService = new PlatformDetailsService();
        }

        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult Users()
        {
            var res = _userManagementService.GetAllUsers();
            return View(res);
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult GetUser(int id)
        {
            var User = _userManagementService.GetUser(id);

            return View(User);
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult DeactiveUser(int id)
        {
            _userManagementService.DeactiveUser(id);

            return RedirectToAction("GetUser", "UserManagement", new { id = id });
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult GetProjects()
        {
            var allProjects = _projectService.GetAllProjects();
            var projectsViewModel = new AdminProjectsViewModel
            {
                ApprovedProjects = allProjects.Where(p => p.ProjectState == ProjectState.Approved),
                PendingProjects = allProjects.Where(p => p.ProjectState == ProjectState.PendingApproval),
                RejectProjects = allProjects.Where(p => p.ProjectState == ProjectState.Rejected)
            };
            ViewBag.allProjects = projectsViewModel;

            return View();
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult ApproveProject(int id)
        {
            _projectService.ApproveProject(id);

            return RedirectToAction("Project", "Home", new { id = id });
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult RejectProject(int id)
        {
            _projectService.RejectProject(id);

            return RedirectToAction("Project", "Home", new { id = id });
        }

        //[Authorize (Roles = "Admin")]
        public ActionResult GetSettings()
        {
            var data = _platformService.GetSettings();

            return View(data);
        }

        [HttpPost]
        public ActionResult GetSettings(PlatformDetailsViewModel model)
        {
            _platformService.SetSetting(model);
            return View();
        }
    }
}