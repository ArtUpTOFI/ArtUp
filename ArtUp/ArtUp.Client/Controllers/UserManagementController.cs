﻿using ArtUp.BankMockServer.Services.Concrete;
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

        public ActionResult TransferMoney(int projectId)
        {
            var currentProject = _projectService.Get(projectId);
            var comissionPercents = _platformService.GetSettings().PlatformComission;
            var comission = currentProject.CurrentMoney * (comissionPercents / 100);
            var transferAmount = currentProject.CurrentMoney - comissionPercents;
            var answer = _bankApi.CreateTransaction("9999999999999", currentProject.AccountNumber, (float)transferAmount);
            var answer2 = _bankApi.CreateTransaction("9999999999999", "9999999999991", (float)transferAmount);
            //currentProject. = null;
            ViewBag.Answer = "Деньги переведены пользователю";

            return View();
        }

        public ActionResult ReturnMoney(int projectId)
        {
            var currentProject = _projectService.Get(projectId);
            var res = _donationService.GetDonations(projectId);

            foreach(var d in res)
            {
                _bankApi.CardTransaction("9999999999999", d.CardNumber, (float)d.Amount);
            }
            ViewBag.Answer = "Деньги возвращены пользователям";
            currentProject.ShortDescription = "Проваленный";
            return View();
        }
    }
}