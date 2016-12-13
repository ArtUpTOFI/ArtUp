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

        public UserManagementController()
        {
            _projectService = new ProjectService();
            _userManagementService = new UserManagementService();
        }

        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            var res = _userManagementService.GetAllUsers();
            return View(res);
        }

        public ActionResult GetUser(int id)
        {
            var User = _userManagementService.GetUser(id);

            return View(User);
        }

        public ActionResult DeactiveUser(int id)
        {
            _userManagementService.DeactiveUser(id);

            return RedirectToAction("GetUser", "UserManagement", new { id = id });
        }

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

        public ActionResult ApproveProject(int id)
        {
            _projectService.ApproveProject(id);

            return RedirectToAction("Project", "Home", new { id = id });
        }

        public ActionResult RejectProject(int id)
        {
            _projectService.RejectProject(id);

            return RedirectToAction("Project", "Home", new { id = id });
        }
    }
}