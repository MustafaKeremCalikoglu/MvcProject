﻿using MvcProject.Models.siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        
        Context c=new Context();
        BlogYorum by = new BlogYorum();

        public ActionResult Index()
        {
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return View(by);
        }
        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();

            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {   

            ViewBag.deger=id;            
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar b)
        {
            c.Yorumlars.Add(b);
            c.SaveChanges();
            return PartialView();
        }
    }
}