using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DetroitHills.DAL;
using DetroitHills.Models;
using DetroitHills.ViewModels;
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
                Session["login"] = userName; 
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
            Session.Abandon();
            return (RedirectToAction("Index", "Home"));
        }

        public ActionResult Register()
        {
            return View();
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

        public ActionResult Videos()
        {
            VideoBL videoBL = new VideoBL();
            VideoVM videoList = new VideoVM();
            videoList.videos = videoBL.GetVideos();
            videoList.videos.Reverse();
            return View(videoList);
        }

        public ActionResult Tour()
        {
            TourBL tourBL = new TourBL();
            TourVM tour = new TourVM();
            tour.tourList = tourBL.GetTour();
            
            return View(tour);
        }

        public ActionResult Shop()
        {
            ItemBL itemBL = new ItemBL();
            ShopVM shopVM = new ShopVM();
            shopVM.shop = itemBL.GetItems();
            return View(shopVM);
        }

        public ActionResult Photos()
        {
            PhotosBL photosBL = new PhotosBL();
            PhotosVM photosVM = new PhotosVM();

            List<Photo> list = photosBL.GetPhotos();
            int i, n, j;
            

            if (list!=null)
            {
                n = 1;
                for (i = 1; i < list.Count; i++)
                {

                    if (list[i].photoalbum != list[i - 1].photoalbum)
                        n += 1;
                }

                for (i=0; i<n; i++)
                {
                    List<Photo> tmp = new List<Photo>();
                    tmp.Add(list[0]);
                    for (j=1; j< list.Count; j++)
                    {
                        if (list[j].photoalbum != list[j - 1].photoalbum)
                            break;
                        else
                        {
                            tmp.Add(list[j]);
                            list.RemoveAt(j);
                        }                            
                    }
                    photosVM.albums.Add(tmp);
                }
            }
            

            return View(photosVM);
        }


    }
}