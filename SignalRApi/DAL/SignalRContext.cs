using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL.Entities;

namespace SignalRApi.DAL
{
    public class SignalRContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-A7AFDHF\\SQLEXPRESS;Initial Catalog=SignalRDB;Integrated Security=true;TrustServerCertificate=True;");
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category>Categories { get; set; }

    }
}
