using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int cariID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string cariAd { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string cariSoyad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(15)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string cariSehir { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string cariMail { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz")]
        public string cariSifre { get; set; }
        public bool durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}