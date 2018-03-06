using System.ComponentModel.DataAnnotations;

namespace WebSeite.Models
{
    public class Kategorie
    {
        [Key]
        public int ProduktKategorieId { get; set; }
        public string Name { get; set; }

    }
}