using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class IstatistikController : Controller
    {
        Context c = new Context();

        // GET: Istatistik
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Sum(x=>x.stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x=>x.stok<=20).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.satisFiyati descending select x.urunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns orderby x.satisFiyati ascending select x.urunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.urunAd=="Buz Dolabı").ToString();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.urunAd == "Leptop").ToString();
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.GroupBy(x => x.marka).OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;
            var deger13 =c.Uruns.Where(u=>u.urunID==(c.SatisHarekets.GroupBy(x => x.urunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.urunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            DateTime bugun = DateTime.Today;
            var deger14 = c.SatisHarekets.Sum(x => x.toplamTutar).ToString();
            ViewBag.d14 = deger14;
            var deger15 = c.SatisHarekets.Count(x => x.tarih==bugun).ToString();
            ViewBag.d15= deger15;
            var deger16 = c.SatisHarekets.Where(x => x.tarih == bugun).Sum(y =>(decimal?)y.toplamTutar).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.cariSehir into g
                        select new GrupSinif
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult parcali1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.departmanAd into g
                         select new GrupSinif2
                         {
                             departman = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult parcali2()
        {
            var sorgu3 = c.Carilers.ToList();
            return PartialView(sorgu3);
        }
        public PartialViewResult parcali3()
        {
            var sorgu4 = c.Uruns.ToList();
            return PartialView(sorgu4);
        }
        public PartialViewResult parcali4()
        {
            var sorgu5 = from x in c.Uruns
                         group x by x.marka into g
                         select new GrupSinif3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu5.ToList());
        }

    }
}