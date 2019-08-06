using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DetroitHills.DAL;
using DetroitHills.Models;
using System.Web.Security;

namespace DetroitHills.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Worldplace()
        {
            return View();
        }

        public ActionResult Delight()
        {
            return View();
        }

        public ActionResult Memory()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            UserBL login = new UserBL();
            if (!login.isValidUser(userName, password))
            {
                ModelState.AddModelError("", "Wrong username or password");
                return View("Login");

            }
            else
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                if (userName == "admin")
                    return RedirectToAction("Index", "Admin");
                else
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return (RedirectToAction("Index", "Home"));
        }

        [HttpPost]
        public ActionResult Register(User u)
        {
            UserBL userBL = new UserBL();

            if (ModelState.IsValid)
            {
                userBL.AddUser(u);
                return RedirectToAction("Login", "Home");
            }
            return View();
        }



    }
}