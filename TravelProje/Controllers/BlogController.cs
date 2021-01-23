using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogYorumlar by = new BlogYorumlar();

        public ActionResult Index()
        {
            using (var c = new Context())
            {
                //var bloglar = c.Blogs.ToList();
                by.deger1 = c.Blogs.ToList();
                by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
                by.deger4 = c.Yorumlars.Take(4).ToList();
                return View(by);
            }

        }

        public ActionResult BlogDetay(int id)
        {
            using (var c = new Context())
            {


                by.deger1 = c.Blogs.Where(x => x.ID == id).ToList();
                by.deger2 = c.Yorumlars.Where(x => x.BlogId == id).ToList();
                by.deger4 = c.Yorumlars.Take(4).ToList();
                by.deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
                //var blogDetay = c.Blogs.Where(x => x.ID == id).ToList();

                return View(by);
            }

        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            using (var c = new Context())
            {
                c.Yorumlars.Add(y);
                c.SaveChanges();
                return PartialView();
            }
        }
    }
}