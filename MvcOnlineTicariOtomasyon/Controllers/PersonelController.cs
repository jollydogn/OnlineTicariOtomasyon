using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()                                               //dropdownList te göstermek için sorgusunu yazdık.
                                           select new SelectListItem
                                           {
                                               Text = x.departmanAd,
                                               Value = x.departmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;//dgr1 adlı değişkenimin içersiinde deger1 de ki degerleri ata ve view a göndermek için hazır et demek oluyur. biz bunu PersonelEkle sayfasına atıcaz.
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);//dosya adı
                string uzanti = Path.GetExtension(Request.Files[0].FileName);//uzanti alma
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel = "/Image/" + dosyaAdi + uzanti;
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()                                               //dropdownList te göstermek için sorgusunu yazdık.
                                           select new SelectListItem
                                           {
                                               Text = x.departmanAd,
                                               Value = x.departmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);//dosya adı
                string uzanti = Path.GetExtension(Request.Files[0].FileName);//uzanti alma
                string yol = "~/Image/" + dosyaAdi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.personelGorsel = "/Image/" + dosyaAdi + uzanti;
            }
            var pers = c.Personels.Find(p.personelID);
            pers.personelAd = p.personelAd;
            pers.personelSoyad = p.personelSoyad;
            pers.personelGorsel = p.personelGorsel;
            pers.departmanID = p.departmanID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}