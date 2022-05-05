using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        public int kategoriID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string kategoriAdi { get; set; }

        //her bir kategoride 1 den fazla ürün vardır

        public  ICollection<Urun> Uruns { get; set; }
    }
}