using System;
using System.Data.Entity;

namespace Proba.Models
{
    public class Przedmioty
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }
        public double Cena { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public string Wystawiajacy { get; set; }
    }

    public class PrzedmiotyDBContext : DbContext
    {
        public DbSet<Przedmioty> Przedmioty { get; set; }
    }
}