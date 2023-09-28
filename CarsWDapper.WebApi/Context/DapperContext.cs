using CarsWDapper.WebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CarsWDapper.WebApi.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost,1433;database=CarsWDapperDb;user=sa;password=123456aA*");
        }
        public DbSet<Vehicle> Vehicles { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
