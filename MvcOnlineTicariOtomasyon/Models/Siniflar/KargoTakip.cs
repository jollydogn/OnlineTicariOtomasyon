using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int kargoTakipID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string takipKodu { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(300)]
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
    }
}