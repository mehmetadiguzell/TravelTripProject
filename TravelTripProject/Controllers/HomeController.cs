using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class HomeController : Controller
    {
        Context context = new Context();

        public ActionResult Index()
        {
            var model = context.Blogs.ToList();
            return View(model);
        }
   
        public ActionResult PartialSol()
        {
            var result = context.Blogs.OrderByDescending(n => n.Id).Take(2).ToList();
            return PartialView(result);
        }

        public ActionResult PartialSag()
        {
            var result = context.Blogs.Where(n => n.Id==1).ToList();
            return PartialView(result);
        }

        public ActionResult TopBlog()
        {
            var result = context.Blogs.Take(3).ToList();
            return PartialView(result);
        }

        public ActionResult TopPlacesLeft()
        {
            var result = context.Blogs.Take(3).ToList();
            return PartialView(result);
        }

        public ActionResult TopPlacesRight()
        {
            var result = context.Blogs.OrderByDescending(n => n.Id).Take(3).ToList();
            return PartialView(result);
        }


    }
}