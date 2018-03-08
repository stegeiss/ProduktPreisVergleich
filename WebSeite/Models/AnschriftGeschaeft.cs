using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeite.Models
{
    public class AnschriftGeschaeft
    {
        [Key]
        public int AnschriftGeschaeftID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? Kundennummer { get; set; }
        public string Strasse { get; set; }
        public string Hausnummer { get; set; }
        public int? PLZ { get; set; }
        public string Ort { get; set; }
        public string Zusatz { get; set; }
        public string Email { get; set; }
        public string Homepage { get; set; }

        public string Telefonnummer { get; set; }
        public string Fax { get; set; }
        public string Handy { get; set; }

        public string OeffnungsZeitenMontag { get; set; }
        public string OeffnungsZeitenDienstag { get; set; }
        public string OeffnungsZeitenMittwoch { get; set; }
        public string OeffnungsZeitenDonnerstag { get; set; }
        public string OeffnungsZeitenFreitag { get; set; }
        public string OeffnungsZeitenSamstag { get; set; }
        public string OeffnungsZeitenSonntag { get; set; }
    }
}