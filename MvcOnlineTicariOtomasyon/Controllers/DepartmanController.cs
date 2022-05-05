using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
        [Authorize(Roles ="A")]
        [HttpGet] 
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            c.SaveChanges();
           return RedirectToAction("Index");
        }
        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmans.Find(id);
            return View("DepartmanGetir", dep);
        }
        public ActionResult DepartmanGüncelleme(Departman d)
        {
            var dep = c.Departmans.Find(d.departmanID);
            dep.departmanAd = d.departmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.departmanID == id).ToList();
            var dpt = c.Departmans.Where(x => x.departmanID == id).Select(y => y.departmanAd).FirstOrDefault();
            ViewBag.dptID = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.personelID == id).ToList();
            var dpt = c.Personels.Where(x => x.personelID == id).Select(y => y.personelAd +" "+ y.personelSoyad).FirstOrDefault();
            ViewBag.dptAd = dpt;
            return View(degerler);
        }
    }
}