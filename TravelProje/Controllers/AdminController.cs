using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProje.Models.Sınıflar;

namespace TravelProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            using (var c = new Context())
            {
                var deger = c.Blogs.ToList();
                return View(deger);
            }


        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            using (var c = new Context())
            {

                return View();
            }

        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            using (var c = new Context())
            {
                c.Blogs.Add(p);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult BlogSil(int id)
        {
            using (var c = new Context())
            {
                var b = c.Blogs.Find(id);
                c.Blogs.Remove(b);
                c.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult BlogGetir(int id)
        {
            using (var c = new Context())
            {
                var b = c.Blogs.Find(id);

                return View("BlogGetir", b);
            }

        }
        public ActionResult BlogGuncelle(Blog b)
        {
            using (var c = new Context())
            {
                var blg = c.Blogs.Find(b.ID);
                blg.Baslik = b.Baslik;
                blg.Aciklama = b.Aciklama;
                blg.BlogImage = b.BlogImage;
                blg.Tarih = b.Tarih;
                blg.Yorumlars = b.Yorumlars;
                c.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        public ActionResult YorumListesi()
        {
            using (var c = new Context())
            {
                var yorumlar = c.Yorumlars.ToList();
                return View(yorumlar);


            }
        }
        public ActionResult YorumSil(int id)
        {
            using (var c = new Context())
            {
                var b = c.Yorumlars.Find(id);
                c.Yorumlars.Remove(b);
                c.SaveChanges();
                return RedirectToAction("YorumListesi");
            }

        }
        public ActionResult YorumGetir(int id)
        {
            using (var c = new Context())
            {
                var yorum = c.Yorumlars.Find(id);

                return View("YorumGetir", yorum);
            }

        }
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            using (var c = new Context())
            {
                var yorum = c.Yorumlars.Find(y.ID);
                yorum.KullaniciAdi = y.KullaniciAdi;
                yorum.Mail = y.Mail;
                yorum.Yorum = y.Yorum;
                c.SaveChanges();
                return RedirectToAction("YorumListesi");
                
            }

        }
    }
}