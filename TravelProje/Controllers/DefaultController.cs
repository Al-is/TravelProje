using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (var c = new Context())
            {
                var degerler = c.Blogs.ToList();
                return View(degerler);
            }

        }
        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            using (var c = new Context())
            {
                var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
                return PartialView(degerler);
            }
        }
        public PartialViewResult Partial2()
        {
            using (var c = new Context())
            {
                var deger = c.Blogs.Where(x => x.ID == 1).ToList();
                return PartialView(deger);
            }
        }
        public PartialViewResult Partial3()
        {
            using (var c = new Context())
            {
                var deger = c.Blogs.Take(10).ToList();
                return PartialView(deger);
            }
        }

        public PartialViewResult Partial4()
        {
            using (var c = new Context())
            {
                var deger = c.Blogs.ToList();
                return PartialView(deger);
            }
        }
    }
}