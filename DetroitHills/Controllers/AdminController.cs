﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DetroitHills.Models;
using DetroitHills.ViewModels;
using System.Net.Mail;
using DetroitHills.Filters;

namespace DetroitHills.Controllers
{
    [Culture]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(Post p, string text, string text_lng)
        {
            string filename = "blog1.jpg";
            if (p.upload!= null)
            {
                filename = System.IO.Path.GetFileName(p.upload.FileName);
                p.upload.SaveAs(Server.MapPath("~/Assets/img/bg-img/" + filename));
            }

            
            p.image = "/Assets/img/bg-img/" + filename;
            p.date = DateTime.Now;
            p.numOfComments = 0;
            p.text = text;
            p.text_lng = text_lng;
            PostBL postBL = new PostBL();
            if (ModelState.IsValid)
            {
                postBL.AddPost(p);
                return RedirectToAction("News", "Home");
            }
            return View();
            
        }

        public ActionResult EditPost(int id)
        {
            PostBL postBL = new PostBL();
            List<Post> postList = postBL.GetPosts();
            Post post = postList.Where(u => u.PostId == id).Single();
            return View(post);
        }

        
        [HttpPost]
        public ActionResult EditPost(Post p, string text, string text_lng)
        {
            if (p.upload != null)
            {
                string filename = System.IO.Path.GetFileName(p.upload.FileName);
                p.upload.SaveAs(Server.MapPath("~/Assets/img/bg-img/" + filename));
                p.image = "/Assets/img/bg-img/" + filename;
            }
            p.date = DateTime.Now;
            p.text = text;
            p.text_lng = text_lng;
            
                PostBL postBL = new PostBL();
                postBL.EditPost(p);
                return RedirectToAction("News", "Home");
            
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            PostBL postBL = new PostBL();
            List<Post> postList = postBL.GetPosts();
            Post post = postList.Where(u => u.PostId == id).Single();
            postBL.DeletePost(post);

            NewsVM news = new NewsVM();
            news.posts = postBL.GetPosts();
            news.posts.Reverse();

            return RedirectToAction("News", "Home", news);
        }

        public ActionResult AddVideo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddVideo(Video v)
        {
            VideoBL videoBL = new VideoBL();
            if (ModelState.IsValid)
            {
                videoBL.AddVideo(v);
                return RedirectToAction("Videos", "Home");
            }
            return View();
        }

        public ActionResult EditVideo (int id)
        {
            VideoBL videoBL = new VideoBL();
            List<Video> postList = videoBL.GetVideos();
            Video video = postList.Where(u => u.VideoId == id).Single();
            return View(video);
        }

        [HttpPost]
        public ActionResult EditVideo(Video v)
        {
            VideoBL videoBL = new VideoBL();
            if (ModelState.IsValid)
            {
                videoBL.EditVideo(v);
                return RedirectToAction("Videos", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteVideo(int id)
        {
            VideoBL videoBL = new VideoBL();
            List<Video> postList = videoBL.GetVideos();
            Video video = postList.Where(u => u.VideoId == id).Single();
            videoBL.DeleteVideo(video);

            VideoVM v = new VideoVM();
            v.videos = videoBL.GetVideos();
            v.videos.Reverse();

            return RedirectToAction("Videos", "Home", v);
        }

        public ActionResult AddConcert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddConcert(Tour t)
        {
            TourBL tourBL = new TourBL();
            if (ModelState.IsValid)
            {
                tourBL.AddConcert(t);
                return RedirectToAction("Tour", "Home");
            }
            return View();
        }

        public ActionResult EditConcert(int id)
        {
            TourBL tourBL = new TourBL();
            List<Tour> postList = tourBL.GetTour();
            Tour tour = postList.Where(u => u.TourId == id).Single();
            return View(tour);
        }

        [HttpPost]
        public ActionResult EditConcert(Tour t)
        {
            TourBL tourBL = new TourBL();
            if (ModelState.IsValid)
            {
                tourBL.EditConcert(t);
                return RedirectToAction("Tour", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteConcert(int id)
        {
            TourBL tourBL = new TourBL();
            List<Tour> postList = tourBL.GetTour();
            Tour tour = postList.Where(u => u.TourId == id).Single();
            tourBL.DeleteConcert(tour);

            TourVM t = new TourVM();
            t.tourList = tourBL.GetTour();
            
            return RedirectToAction("Tour", "Home", t);
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(Item p)
        {
            string filename = "shop_back.jpg";
            if (p.upload != null)
            {
                filename = System.IO.Path.GetFileName(p.upload.FileName);
                p.upload.SaveAs(Server.MapPath("~/Assets/img/bg-img/" + filename));
            }


            p.photo = "/Assets/img/bg-img/" + filename;
            
            ItemBL itemBL = new ItemBL();
            if (ModelState.IsValid)
            {
                itemBL.AddItem(p);
                return RedirectToAction("Shop", "Home");
            }
            return View();

        }

        public ActionResult EditItem(int id)
        {
            ItemBL itemBL = new ItemBL();
            List<Item> itemList = itemBL.GetItems();
            Item item = itemList.Where(u => u.ItemId == id).Single();
            return View(item);
        }


        [HttpPost]
        public ActionResult EditItem(Item p)
        {
            if (p.upload != null)
            {
                string filename = System.IO.Path.GetFileName(p.upload.FileName);
                p.upload.SaveAs(Server.MapPath("~/Assets/img/bg-img/" + filename));
                p.photo = "/Assets/img/bg-img/" + filename;
            }


            if (ModelState.IsValid)
            {
                ItemBL itemBL = new ItemBL();
                itemBL.EditItem(p);
                return RedirectToAction("Shop", "Home");
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            ItemBL itemBL = new ItemBL();
            List<Item> itemList = itemBL.GetItems();
            Item item = itemList.Where(u => u.ItemId == id).Single();
            itemBL.DeleteItem(item);

            ShopVM shopVM = new ShopVM();
            shopVM.shop = itemBL.GetItems();
            
            return RedirectToAction("Shop", "Home", shopVM);
        }

        public ActionResult AddPhotos()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhotos(string albumname, IEnumerable<HttpPostedFileBase> uploads)
        {
            PhotosBL photoBL = new PhotosBL();
            foreach (var file in uploads)
            {
                if (file != null)
                {
                   string filename = System.IO.Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath("~/Assets/img/photoalbums/" + filename));
                    Photo p = new Photo();
                    p.photoalbum = albumname;
                    p.path = "/Assets/img/photoalbums/" + filename;
                    photoBL.AddPhoto(p);
                }
            }

            
            return RedirectToAction("Photos", "Home");
            

        }

        [HttpPost]
        public ActionResult DeletePhoto(int id)
        {

            PhotosBL photoBL = new PhotosBL();
            List<Photo> itemList = photoBL.GetPhotos();
            Photo photo = itemList.Where(u => u.PhotoId == id).Single();
            photoBL.DeletePhoto(photo);

            itemList = photoBL.GetPhotos();
            bool albumExist=false;
            foreach (Photo p in itemList)
            {
                if (p.photoalbum == photo.photoalbum)
                    albumExist = true;
            }

            if (albumExist)
                return RedirectToAction("Album", "Home", new { name = photo.photoalbum });
            else
                return (RedirectToAction("Photos", "Home"));
        }

        public ActionResult Orders()
        {
            OrderBL orderBL = new OrderBL();
            MyOrdersVM list = new MyOrdersVM();

            list.orders = orderBL.GetOrders();

            return View(list);
        }

        public ActionResult EditOrder(int id)
        {
            OrderBL orderBL = new OrderBL();
            List<Order> list = orderBL.GetOrders();
            Order o = list.Where(u => u.OrderId == id).Single();

            return View(o);
        }

        [HttpPost]
        public ActionResult EditOrder(Order o, string newstatus)
        {
            OrderBL obl = new OrderBL();
            if (newstatus != "")
            {
                o.status = newstatus;
                o.status_lng = obl.Status_Lng(newstatus);
            }
            
            obl.EditOrder(o);

            return RedirectToAction("Orders", "Admin");
        }

        public ActionResult Newsletter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Newsletter(string subject, string text)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;            
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("detroithillsnews@gmail.com", "ZacharSabin");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("detroithillsnews@gmail.com");
            UserBL userBl = new UserBL();
            List<User> list = userBl.GetUsers();
            foreach (User user in list)
            {
                if (user.username == "admin")
                    continue;
                mail.To.Add(user.email);


            }
            mail.Subject = subject;
            mail.Body = text;
            
            client.Send(mail);
            
            return View("Index");
        }
    }
}