using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        Context context = new Context();
        BlogYorum yorum = new BlogYorum();

        public ActionResult Index()
        {
            yorum.WmBlog = context.Blogs.ToList();
            yorum.SonBloglar = context.Blogs.OrderByDescending(m => m.Id).ToList();
            return View(yorum);
        }

        public ActionResult BlogDetay(int id = 0)
        {
            yorum.WmBlog = context.Blogs.Where(m => m.Id == id).ToList();
            yorum.WmYorum = context.Yorumlars.Where(m => m.BlogId == id).ToList();
            if (yorum == null)
            {
                return HttpNotFound();
            }
            return View(yorum);
        }

        public ActionResult YorumYap(int id=0)
        {
            ViewBag.sayi = id;
            return PartialView();
        }
        [HttpPost]
        public ActionResult YorumYap(Yorumlar comment)
        {
            context.Yorumlars.Add(comment);
            context.SaveChanges();
            return PartialView();
        }
    }
}