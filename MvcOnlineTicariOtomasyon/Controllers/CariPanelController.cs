using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();
        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["cariMail"];
            var degerler = c.Mesajlars.Where(x => x.alici == mail).ToList();
            ViewBag.m = mail;
            var mailID = c.Carilers.Where(x => x.cariMail == mail).Select(y => y.cariID).FirstOrDefault();
            ViewBag.mid = mailID;
            var toplamSatis = c.SatisHarekets.Where(x => x.cariID == mailID).Count();
            ViewBag.toplamSatis = toplamSatis;
            var toplamTutarr = c.SatisHarekets.Where(x => x.cariID == mailID).Sum(y => y.toplamTutar);
            ViewBag.toplamTutarr = toplamTutarr;
            var toplamUrunSayisi = c.SatisHarekets.Where(x => x.cariID == mailID).Sum(y => y.adet);
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;
            var adsoyad = c.Carilers.Where(x => x.cariID == mailID).Select(y => y.cariAd + " " + y.cariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["cariMail"];
            var id = c.Carilers.Where(x => x.cariMail == mail.ToString()).Select(y => y.cariID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.cariID == id).ToList();

            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["cariMail"];
            var degerler = c.Mesajlars.Where(x => x.alici == mail).OrderByDescending(x => x.mesajID).ToList();
            var gelenSayisi = c.Mesajlars.Count(x => x.alici == mail).ToString();
            var gidenSayisi = c.Mesajlars.Count(x => x.gonderen == mail).ToString();

            ViewBag.gidenMesaj = gidenSayisi;
            ViewBag.gelenMesaj = gelenSayisi;
            return View(degerler);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["cariMail"];
            var degerler = c.Mesajlars.Where(x => x.gonderen == mail).OrderByDescending(x => x.mesajID).ToList();
            var gidenSayisi = c.Mesajlars.Count(x => x.gonderen == mail).ToString();

            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = c.Mesajlars.Count(x => x.alici == mail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            return View(degerler);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.mesajID == id).ToList();
            var mail = (string)Session["cariMail"];
            var gidenSayisi = c.Mesajlars.Count(x => x.gonderen == mail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = c.Mesajlars.Count(x => x.alici == mail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            return View(degerler);
        }
        [HttpGet]
        [Authorize]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["cariMail"];
            var gidenSayisi = c.Mesajlars.Count(x => x.gonderen == mail).ToString();
            ViewBag.gidenMesaj = gidenSayisi;
            var gelenSayisi = c.Mesajlars.Count(x => x.alici == mail).ToString();
            ViewBag.gelenMesaj = gelenSayisi;
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["cariMail"];
            m.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.gonderen = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            kargo = kargo.Where(y => y.takipKodu.Contains(p));
            return View(kargo.ToList());
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.takipKodu == id).OrderByDescending(x=>x.tarih).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");

        }

        public PartialViewResult Partial1()
        {
            var mail = (string)Session["cariMail"];
            var id = c.Carilers.Where(x => x.cariMail == mail).Select(y => y.cariID).FirstOrDefault();
            var cariBul = c.Carilers.Find(id);
            return PartialView("Partial1", cariBul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.gonderen == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.cariID);
            cari.cariAd = cr.cariAd;
            cari.cariSoyad = cr.cariSoyad;
            cari.cariSifre = cr.cariSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}