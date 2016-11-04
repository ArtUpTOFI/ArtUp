using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtUp.BankMockServer.Services.Concrete;
using ArtUp.BankMockServer.Services.Intarfaces;
using ArtUp.BankMockUI.Models;

namespace ArtUp.BankMockUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserApiService service;
        public AccountController()
        {
            service = new UserApiService();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(EnterViewModel model)
        {
            var dbItem = service.GetAccountByNumber(model.Number);
            if (dbItem != null && dbItem.FirstName == model.FirstName && dbItem.LastName == model.LastName)
                return RedirectToAction("GetAccount", "Account", new { dbItem.Id });
            return Content("<h2>Incorrect data</h2>");
        }

        public ActionResult GetAccount(int id)
        {
            var dbItem = service.GetAccount(id);
            AccountViewModel model = new AccountViewModel { FirstName = dbItem.FirstName,
                LastName = dbItem.LastName,
                Money = dbItem.Money,
                Adress = dbItem.Adress,
                Nubmer = dbItem.Nubmer,
                PatronomicName = dbItem.PatronomicName,
                Type = dbItem.Type};

            return View(model);
        }
    }
}