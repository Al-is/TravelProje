using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            using (var c = new Context())
            {
                var degerler = c.Hakkimizdas.ToList();
                return View(degerler);
            }
        }
    }
}