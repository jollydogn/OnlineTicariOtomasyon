using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int personelID { get; set; }

        [Display(Name ="Personel Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string personelAd { get; set; }

        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string personelSoyad { get; set; }

        [Display(Name = "Görsel")]
        [Column(TypeName = "varchar")]
        [StringLength(1000)]
        public string personelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        
        public int departmanID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}