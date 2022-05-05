using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var ftr = c.Faturalars.Find(id);
            return View("FaturaGetir", ftr);
        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.faturaID);
            fatura.faturaSiraNo = f.faturaSiraNo;
            fatura.faturaSaat = f.faturaSaat;
            fatura.faturaTarih = f.faturaTarih;
            fatura.teslimAlan = f.teslimAlan;
            fatura.teslimEden = f.teslimEden;
            fatura.faturaVergiDairesi = f.faturaVergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.faturaID == id).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class3 cs = new Class3();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        public ActionResult FaturaKaydet(string faturaSiraNo, DateTime tarih,string faturaVergiDairesi,
            string teslimEden,string teslimAlan,string Toplam,string saat,FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.faturaSiraNo = faturaSiraNo;
            f.faturaVergiDairesi = faturaVergiDairesi;
            f.faturaTarih = tarih;
            f.teslimAlan = teslimAlan;
            f.teslimEden = teslimEden;
            f.Toplam = Convert.ToInt32(Toplam);
            f.faturaSaat = saat;
            c.Faturalars.Add(f);
            foreach (var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.aciklama = x.aciklama;
                fk.birimFiyat = x.birimFiyat;
                fk.faturaID = x.faturaKalemID;
                fk.miktar = x.miktar;
                fk.tutar = x.tutar;
                c.FaturaKalems.Add(fk);
            }
            c.SaveChanges();
            return Json("İşlem Başarılı",JsonRequestBehavior.AllowGet);
        }
    }
}