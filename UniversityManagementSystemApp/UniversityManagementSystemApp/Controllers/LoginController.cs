using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UniversityManagementSystemApp.Manager;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Controllers
{
    public class LoginController : Controller
    {
        private LoginManager aLoginManager;
        public LoginController()
        {
            aLoginManager = new LoginManager();
        }
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login aLogin)
        {
            ViewBag.message = aLoginManager.AuthorizedUser(aLogin);
            if (ViewBag.message == "True")
            {
                Session["User"] = "True";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
	}   
}