using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int faturaKalemID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string aciklama { get; set; }
        public int miktar { get; set; }
        public decimal birimFiyat { get; set; }
        public decimal tutar { get; set; }

        public int faturaID { get; set; }
        public virtual Faturalar Faturalar { get; set; }

    }
}