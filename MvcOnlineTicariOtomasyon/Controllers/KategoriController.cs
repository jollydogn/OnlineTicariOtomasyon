using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index( int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }

        public ActionResult KategoriGüncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.kategoriID);
            ktgr.kategoriAdi = k.kategoriAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        //-----------------Kat seçtiğimde onun urunlerini getirme-------------------------
        public ActionResult Deneme()
        {
            Class2 cs2 = new Class2();
            cs2.Kategoriler = new SelectList(c.Kategoris, "kategoriID", "kategoriAdi");
            cs2.Urunler= new SelectList(c.Uruns, "urunID", "urunAd");
            return View(cs2);
        }
        public JsonResult UrunGetir(int p)
        {
            var urunListesi = (from x in c.Uruns
                               join y in c.Kategoris on x.Kategori.kategoriID equals y.kategoriID
                               where x.Kategori.kategoriID == p
                               select new
                               {
                                   Text=x.urunAd,
                                   Value=x.urunID.ToString()
                               }).ToList();
            return Json(urunListesi,JsonRequestBehavior.AllowGet);
        }

        //-----------------Kat seçtiğimde onun urunlerini getirme-------------------------
    }
}