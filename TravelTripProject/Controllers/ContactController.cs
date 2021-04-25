using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        Context context = new Context();


        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Message(Iletisim contact)
        {
            context.Iletisims.Add(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}