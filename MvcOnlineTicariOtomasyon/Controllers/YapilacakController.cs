using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context c = new Context();
        // GET: Yapilacak
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();
            ViewBag.dg1 = deger1;
            var deger2 = c.Uruns.Count().ToString();
            ViewBag.dg2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.dg3 = deger3;
            var deger4 = (from x in c.Carilers select x.cariSehir).Distinct().Count().ToString();
            ViewBag.dg4 = deger4;
            var deger = c.Yapilacaks.ToList();
            return View(deger); 
        }
    }
}