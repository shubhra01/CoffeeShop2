using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace CoffeeShop.Areas.Admin.Data
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext(DbContextOptions<CoffeeContext> options ):base(options)
        {

        }

        public DbSet<Welcome> Welcomes { get; set; }
        public DbSet<MusicalInstrument> MusicalInstruments { get; set; }
        public DbSet<Info> Infos { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Welcome>().ToTable("Welcome");
            modelBuilder.Entity<MusicalInstrument>().ToTable("MusicalInstrument");
            modelBuilder.Entity<Info>().ToTable("Info");
            modelBuilder.Entity<Drink>().ToTable("Drink");
        }
    }
}
