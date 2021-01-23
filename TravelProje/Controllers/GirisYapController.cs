using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin ad)
        {
            using (var c = new Context())
            {
                var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == ad.Kullanici && x.Sifre == ad.Sifre);
                if (bilgiler != null)
                {
                    FormsAuthentication.SetAuthCookie(bilgiler.Kullanici, false);
                    Session["Kullanici"] = bilgiler.Kullanici.ToString();
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    
                    return View();
                }

            }

        }

        public ActionResult LogOut()
        {
            using (var c = new Context())
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Login", "GirisYap");
            }
        }
    }
}