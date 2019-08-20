using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DetroitHills.Models;
using DetroitHills.ViewModels;

namespace DetroitHills.Controllers
{
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
        public ActionResult CreatePost(Post p)
        {
            string filename = "blog1.jpg";
            if (p.upload!= null)
            {
                filename = System.IO.Path.GetFileName(p.upload.FileName);
                p.upload.SaveAs(Server.MapPath("~/Assets/img/bg-img/" + filename));
            }

            
            p.image = "/Assets/img/bg-img/" + filename;
            p.date = DateTime.Now;

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
        public ActionResult EditPost(Post p, HttpPostedFileBase image)
        {
            if (image != null)
            {
                string filename = System.IO.Path.GetFileName(image.FileName);
                image.SaveAs(Server.MapPath("~/Assets/img/bg-img/" + filename));
                p.image = "/Assets/img/bg-img/" + filename;
            }

            
            if (ModelState.IsValid)
            {
                PostBL postBL = new PostBL();
                postBL.EditPost(p);
                return RedirectToAction("News", "Home");
            }
            return View(p);
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
    }
}