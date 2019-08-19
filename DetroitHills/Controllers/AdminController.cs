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
    }
}