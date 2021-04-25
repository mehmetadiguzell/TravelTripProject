using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Classes;

namespace TravelTripProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        Context context = new Context();

        
        public ActionResult Index()
        {
            var model = context.Blogs.ToList();
            return View(model);
        }

        public ActionResult BlogEkle()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult BlogEkle(Blog blog)
        {
            Blog addData = new Blog
            {
                Baslik = blog.Baslik,
                Tarih=DateTime.Now,
                BlogImage = blog.BlogImage,
                Aciklama = blog.Aciklama               
            };
            context.Blogs.Add(addData);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id=0)
        {
            var result = context.Blogs.Find(id);
            context.Blogs.Remove(result);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogFormu(int id = 0)
        {
            var result = context.Blogs.Find(id);
            return View("BlogFormu", result);
        }

        public ActionResult BlogGuncelle(Blog blog)
        {
            var result = context.Blogs.Find(blog.Id);
            result.Aciklama = blog.Aciklama;
            result.Baslik = blog.Baslik;
            result.BlogImage = blog.BlogImage;
            result.Tarih = DateTime.Now;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var model = context.Yorumlars.ToList();
            return View(model);
        }
        public ActionResult YorumSil(int id = 0)
        {
            var result = context.Yorumlars.Find(id);
            context.Yorumlars.Remove(result);
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumFormu(int id = 0)
        {
            var result = context.Yorumlars.Find(id);
            return View("YorumFormu", result);
        }

        public ActionResult YorumGuncelle(Yorumlar gelenVeri)
        {
            var result = context.Yorumlars.Find(gelenVeri.Id);
            result.KullaniciAdi = gelenVeri.KullaniciAdi;
            result.Mail = gelenVeri.Mail;
            result.Yorum = gelenVeri.Yorum;
            context.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        //iletişim

        public ActionResult Mesajlar()
        {
            var model = context.Iletisims.ToList();
            return View(model);
        }
        public ActionResult MesajSil(int id = 0)
        {
            var result = context.Iletisims.Find(id);
            context.Iletisims.Remove(result);
            context.SaveChanges();
            return RedirectToAction("Mesajlar");
        }

        //hakkkımızda

        public ActionResult Hakkimizda()
        {
            var model = context.Hakkimizdas.ToList();
            return View(model);
        }

        public ActionResult HakkimizdaFormu(int id = 0)
        {
            var result = context.Hakkimizdas.Find(id);
            return View("HakkimizdaFormu", result);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda hakkimizda)
        {
            var result = context.Hakkimizdas.Find(hakkimizda.Id);
            result.FotoUrl = hakkimizda.FotoUrl;
            result.Aciklama = hakkimizda.Aciklama;
            context.SaveChanges();
            return RedirectToAction("Hakkimizda");
        }
       
    }
}