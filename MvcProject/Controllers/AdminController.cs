using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.siniflar;
namespace MvcProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogGetir",b);
        }
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik=b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListele()
        {
            var result = c.Yorumlars.ToList();
            return View(result);
        }

        public ActionResult YorumSil(int id) 
        { 
            var b=c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListele");

        }
        public ActionResult YorumGetir(int id)
        {
            var b = c.Yorumlars.Find(id);
            return View("YorumGetir", b);
        }
        public ActionResult YorumGuncelle(Yorumlar b)
        {
            var blg = c.Yorumlars.Find(b.ID);
            blg.KullaniciAdi = b.KullaniciAdi;
            blg.Mail = b.Mail;
            blg.Yorum = b.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListele");
        }
    }
}