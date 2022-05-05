using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.urunAd.Contains(p));
            }
            return View(urunler.ToList());

        }
        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()                                               //dropdownList te göstermek için sorgusunu yazdık.
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAdi,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;//dgr1 adlı değişkenimin içersiinde deger1 de ki degerleri ata ve view a göndermek için hazır et demek oluyur. biz bunu UrunEkleme sayfasına atıcaz.
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var silinecekDeger = c.Uruns.Find(id);
            silinecekDeger.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {


            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()                                               //dropdownList te göstermek için sorgusunu yazdık.
                                           select new SelectListItem
                                           {
                                               Text = x.kategoriAdi,
                                               Value = x.kategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;//dgr1 adlı değişkenimin içersiinde deger1 de ki degerleri ata ve view a göndermek için hazır et demek oluyur. biz bunu UrunEkleme sayfasına atıcaz.


            var guncellenecekDeger = c.Uruns.Find(id);
            return View("UrunGetir", guncellenecekDeger);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = c.Uruns.Find(p.urunID);
            urun.alisFiyati = p.alisFiyati;
            urun.satisFiyati = p.satisFiyati;
            urun.marka = p.marka;
            urun.durum = p.durum;
            urun.stok = p.stok;
            urun.urunAd = p.urunAd;
            urun.urunGorsel = p.urunGorsel;
            urun.KategoriID = p.KategoriID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.cariAd + " " + x.cariSoyad,
                                               Value = x.cariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.personelAd + " " + x.personelSoyad,
                                               Value = x.personelID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.urunID;
            ViewBag.dgr4 = deger1.satisFiyati;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}