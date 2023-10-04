using CarsWDapper.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace CarsWDapper.WebUI.Context
{
    public class EfContext : DbContext
    {

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            // Önbellekleme işlemini iptal etmek için aşağıdaki kodu buraya yerleştirin
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost,1433;database=CarsWEfDb;user=sa;password=123456aA*");
        }
        public DbSet<Vehicle> Vehicles { get; set; }

       
    }
}
