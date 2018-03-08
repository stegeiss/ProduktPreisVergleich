using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeite.Models
{
    public class Preis
    {
        [Key]
        public int PreisId { get; set; }
        public double Kosten { get; set; }
        public string PreisDatum { get; set; }
        public int? ProduktId { get; set; }
        public Produkt Produkt { get; set; }
        public int AnschriftGeschaeftID { get; set; }
        public AnschriftGeschaeft Anschrift { get; set; }
    }
}
