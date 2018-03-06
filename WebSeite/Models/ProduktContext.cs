using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeite.Models
{
    public class ProduktContext : DbContext
    {
        public ProduktContext(DbContextOptions<ProduktContext> options) : base(options)
        {

        }
        public DbSet<Produkt> Produkt { get; set; }
        public DbSet<AnschriftHersteller> Hersteller { get; set; }
        public DbSet<AnschriftGeschaeft> Geschaeft { get; set; }
        public DbSet<Preis> Preis { get; set; }
        public DbSet<Kategorie> Kategorie { get; set; }
    }
}
