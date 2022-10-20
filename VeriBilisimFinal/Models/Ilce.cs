using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeriBilisimFinal.Models
{
    public class Ilce
    {
        [Key]
        public int IlceID { get; set; }
        public IL il { get; set; }
        [Required]
        public string IlceAd { get; set; }
    }
}
