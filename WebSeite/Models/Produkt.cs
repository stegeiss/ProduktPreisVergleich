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
        Kg = 2,
        ProKilo = 3
    }
    public class Produkt
    {
        [Key]
        public int ProduktId { get; set; }
        public int AnschriftHerstellerID { get; set; }
        public AnschriftHersteller Hersteller { get; set; }
        public string ProduktKategorieId { get; set; }
        //Fleisch
        public Kategorie ProduktKategorie { get; set; }
        //Rindfleisch
        public string ProduktTyp { get; set; }
        //Steak
        public string ProduktName { get; set; }
        //Frisch
        public string Zusatztext { get; set; }
        public string Inhalt { get; set; }
        public InhaltMesseinheit InhaltMesseinheit { get; set; }
        public bool IstBio { get; set; }
        public string Produktcode { get; set; }

        public ICollection<Preis> Preis { get; set; }



    }
}
