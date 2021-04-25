using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;
using System.Web.Security;

namespace TravelTripProject.Controllers
{
    public class GirisYapController : Controller
    {
        Context context = new Context();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var result = context.Admins.FirstOrDefault(m => m.KullaniciAdi == admin.KullaniciAdi && m.Sifre == admin.Sifre);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.KullaniciAdi, false);
                Session["KullaniciAdi"] = result.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Admin");
            }
            return View();

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}