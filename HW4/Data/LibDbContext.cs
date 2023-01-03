using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using HW4.Models;

namespace HW4.Data
{
    public class LibDbContext : DbContext
    {
        public DbSet<DbLibraries> Libraries { get; set; }
        public DbSet<DbBooks> Books { get; set; }
        public DbSet<DbUsers> Users { get; set; }
        public DbSet<DbOrders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=Uvarov;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
