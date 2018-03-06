using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeite.Models
{
    public enum InhaltMesseinheit
    {
        Liter = 1,
        Kg = 2
    }
    public class Produkt
    {
        [Key]
        public int ProduktId { get; set; }
        public int AnschriftHerstellerID { get; set; }
        public AnschriftHersteller Hersteller { get; set; }
        public string Produktname { get; set; }
        public string Inhalt { get; set; }
        public InhaltMesseinheit InhaltMesseinheit { get; set; }
        public string Zusatztext { get; set; }
        public string Produktcode { get; set; }
        public string ProduktKategorieId { get; set; }
        public Kategorie ProduktKategorie { get; set; }

        public ICollection<Preis> Preis { get; set; }



    }
}
