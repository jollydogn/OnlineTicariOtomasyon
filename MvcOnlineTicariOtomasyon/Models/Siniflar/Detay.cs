using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int detayID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string urunAd { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string urunBilgi { get; set; }
    }
}