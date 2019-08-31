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
            p.numOfComments = 0;
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

            PhotosVM photosVM = new PhotosVM();

            List<Photo> list = photoBL.GetPhotos();
            int i, n, j;

            photosVM.albums = new List<List<Photo>>();


            if (list != null)
            {

                n = 1;
                for (i = 1; i < list.Count; i++)
                {

                    if (list[i].photoalbum != list[i - 1].photoalbum)
                        n += 1;
                }

                for (i = 0; i < n; i++)
                {

                    List<Photo> tmp = new List<Photo>();
                    tmp.Add(list[0]);

                    for (j = 0; j < list.Count; j++)
                    {
                        if (list[1].photoalbum != list[0].photoalbum)
                            break;
                        else
                        {
                            tmp.Add(list[1]);
                            list.RemoveAt(0);
                        }
                    }
                    photosVM.albums.Add(tmp);
                    list.RemoveAt(0);
                }

            }

            return RedirectToAction("Photos", "Home", photosVM);
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
        public ActionResult EditOrder(Order o)
        {
            OrderBL obl = new OrderBL();
            obl.EditOrder(o);

            return RedirectToAction("Orders", "Admin");
        }
    }
}