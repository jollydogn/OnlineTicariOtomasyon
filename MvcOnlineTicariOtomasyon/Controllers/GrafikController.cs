using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün stok sayısı").AddLegend("stok").AddSeries
                ("Değerler", xValue: new[] { "Mobilya", "Bilgisayar", "Ofis Eşyaları" }, yValues: new[] { 23, 14, 32 }).Write() ;
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }
        Context c = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.urunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.stok));
            var grafik = new Chart(width: 800,height:800)
            .AddTitle("Stoklar")
            .AddSeries(chartType:"pie",name:"Stok",xValue:xvalue,yValues:yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(Urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif1> Urunlistesi() {
            List<sinif1> snf = new List<sinif1>();
            snf.Add(new sinif1()
            {
                urunAd = "Bilgisayar",
                stokSayisi = 120
            });
            snf.Add(new sinif1()
            {
                urunAd = "Küçük Ev",
                stokSayisi = 32
            });
            snf.Add(new sinif1()
            {
                urunAd = "katrgo",
                stokSayisi = 44
            });

            return snf;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(Urunlistesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<sinif2> Urunlistesi2()
        {
            List<sinif2> snf = new List<sinif2>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new sinif2
                {
                    urun = x.urunAd,
                    stok = x.stok
                }).ToList();
            }
                return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }
    }
}