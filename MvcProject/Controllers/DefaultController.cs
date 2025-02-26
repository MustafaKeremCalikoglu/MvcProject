﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.siniflar;

namespace MvcProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c= new Context();
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        public ActionResult About() 
        {
            return View();
        }
        public PartialViewResult Partial1()
        {   
            var deger=c.Blogs.OrderByDescending(x=>x.ID).Take(2).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial2()
        {
            var deger = c.Blogs.Take(1).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial3()
        {
            var deger = c.Blogs.Take(10).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial4()
        {
            var deger = c.Blogs.Take(3).ToList();
            return PartialView(deger);
        }
        public PartialViewResult Partial5()
        {
            var deger = c.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return PartialView(deger);
        }
    }
}