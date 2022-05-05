using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int faturaID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(6)]
        public string faturaSiraNo { get; set; }
        public DateTime faturaTarih { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(60)]
        public string faturaVergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string faturaSaat { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teslimEden { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string teslimAlan { get; set; }

        public decimal Toplam { get; set; }

        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}