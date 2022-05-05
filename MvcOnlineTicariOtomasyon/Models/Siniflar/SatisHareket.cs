using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int satisHareketID { get; set; }
        public DateTime tarih { get; set; }
        public int adet { get; set; }
        public decimal fiyat { get; set; }
        public decimal toplamTutar { get; set; }

        public int urunID { get; set; }
        public int cariID { get; set; }
        public int personelID { get; set; }
        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }

        //normalde böyleydi ama hata verdiği için yukarıda ki gibi yaptık. Eğer hata verirse böyle yap
        //yukarıda ki gibi yapmazsak  <td>@x.Cariler.cariAd @x.Cariler.cariSoyad</td> bunu yapmıyordu.
        // public Urun Urun { get; set; }
        // public Cariler Cariler { get; set; }
        // public Personel Personel { get; set; }


    }
}