using ArtUp.Client.Models;
using ArtUp.Client.Services;
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
            ViewBag.User = _userManagementService.GetUser(id);

            return View();
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
    }
}