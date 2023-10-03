using CarsWDapper.WebUI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsWDapper.WebUI.Context
{
    public class EfContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =DESKTOP-HFS6ON1\\SQLEXPRESS;initial catalog=CarsWEfDb;integrated security=true;TrustServerCertificate=true");
        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
