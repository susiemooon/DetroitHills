using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DetroitHills.DAL;
using DetroitHills.Filters;
using DetroitHills.Models;
using DetroitHills.ViewModels;
using System.Web.Security;

namespace DetroitHills.Controllers
{
    [Culture]
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

            photosVM.albums = new List<List<Photo>>();

            List<string> names = new List<string>();

            if (list!=null)
            {
                
                n = 1;
                names.Add(list[0].photoalbum);
                for (i = 1; i < list.Count; i++)
                {

                    if (list[i].photoalbum != list[i - 1].photoalbum)
                    {
                        if (!names.Contains(list[i].photoalbum))
                        {
                            n += 1;
                            names.Add(list[i].photoalbum);
                        }
                    }
                }

                for (i = 0; i < n; i++)
                {
                    
                    List<Photo> tmp = new List<Photo>();
                    foreach (Photo p in list)
                    {
                        if (p.photoalbum == names[i])
                            tmp.Add(p);
                    }
                    
                    photosVM.albums.Add(tmp);
                    
                }
                
            }
            photosVM.albums.Reverse();
            return View(photosVM);
        }

        public ActionResult Album(string name)
        {
            AlbumVM albumVM = new AlbumVM();
            PhotosBL photosBL = new PhotosBL();
            List<Photo> list = photosBL.GetPhotos();
            albumVM.album = new List<Photo>();
            foreach (Photo p in list)
            {
                if (p.photoalbum == name)
                    albumVM.album.Add(p);
            }
            if (albumVM.album == null)
                return RedirectToAction("Photos", "Home");
            return View(albumVM);
        }

        
        public ActionResult News()
        {
            PostBL postBL = new PostBL();
            NewsVM news = new NewsVM();
            news.posts = postBL.GetPosts();
            news.posts.Reverse();
            return View(news);
        }

        public ActionResult Post(int id)
        {
            PostBL postBL = new PostBL();
            List<Post> list = postBL.GetPosts();
            Post post = list.Where(u => u.PostId == id).Single();

            
            return View("Post", post);

        }

        [Authorize]
        public ActionResult Order(int id)
        {
            if (Session["login"] == null)
                return View("Login"); 
            ItemBL orderBL = new ItemBL();
            List<Item> list = orderBL.GetItems();
            Item item = list.Where(u => u.ItemId == id).Single();
            
            OrderVM orderVM = new OrderVM();
            orderVM.item = item;
            orderVM.order = new Models.Order();
            orderVM.order.item = item.name;
            return View("Order", orderVM);
        }

        [HttpPost]
        public ActionResult Order(OrderVM oVM)
        {
            OrderBL orderBL = new OrderBL();
            Order o = oVM.order;
            o.username = Session["login"].ToString();
            o.status = "In Process";
            o.status_lng = orderBL.Status_Lng(o.status);
            if (ModelState.IsValid)
            {
                orderBL.AddOrder(o);
            }
            return RedirectToAction("MyOrders");
        }

        [Authorize]
        public ActionResult MyOrders()
        {
            OrderBL orderBL = new OrderBL();
            List<Order> list = orderBL.GetOrders();
            string user = Session["login"].ToString();
            MyOrdersVM myorders = new MyOrdersVM();
            List<Order> tmp = new List<Models.Order>();
            foreach (Order o in list)
            {
                if (o.username == user)
                    tmp.Add(o);
            }
            myorders.orders = tmp;
                
            return View(myorders);
        }

        
        public ActionResult NewComment(int postId)
        {
            CommentBL commentBL = new CommentBL();
            CommentsVM comVM = new CommentsVM();
            comVM.commentsList = commentBL.FindComments(postId);
            comVM.commentsList.Reverse();
            comVM.newComment = new Comment();
            comVM.newComment.PostId = postId;
            if (Session["login"]!= null)
                 comVM.newComment.userName = Session["login"].ToString();

            return PartialView(comVM);
        }


        [HttpPost]        
        public ActionResult CommentList(CommentsVM comVM)
        {
            comVM.newComment.date = DateTime.Now;

            CommentBL commentBL = new CommentBL();
            commentBL.AddComment(comVM.newComment);
            int postId = comVM.newComment.PostId;
            comVM.commentsList = commentBL.FindComments(postId);
            comVM.commentsList.Reverse();
            
            PostBL postBL = new PostBL();
            List<Post> list = postBL.GetPosts();
            Post post = list.Where(u => u.PostId == postId).Single();
            post.numOfComments += 1;
            postBL.EditPost(post);

            return PartialView("CommentList", comVM);
        }

        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            // Список культур
            List<string> cultures = new List<string>() { "en", "ru" };
            if (!cultures.Contains(lang))
            {
                lang = "en";
            }
            
            HttpCookie cookie = Request.Cookies["lang"];
            if (cookie != null)
                cookie.Value = lang;   // если куки уже установлено, то обновляем значение
            else
            {

                cookie = new HttpCookie("lang");
                cookie.HttpOnly = false;
                cookie.Value = lang;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            Session["lang"] = lang;
            return Redirect(returnUrl);
        }
    }
}