using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int mesajID { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string gonderen { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string alici { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string konu { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(2000)]
        public string icerik { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime tarih { get; set; }

    }
}