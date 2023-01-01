using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using HW4.Models;

namespace HW4.Data
{
    public class LibContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Port=5432;Database=Lib;Username=postgres;Password=poo");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbBooks>()
                .HasOne(o=>o.Library)
                .WithMany(o=>o.Books)
                .HasForeignKey(o=>o.LibraryId);

            builder.Entity<DbOrders>()
                .HasOne(o => o.Book)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.BookId);

            builder.Entity<DbOrders>()
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId);
        }

        public DbSet<DbLibraries> Libraries { get; set; }
        public DbSet<DbBooks> Books { get; set; }
        public DbSet<DbUsers> Users { get; set; }
        public DbSet<DbOrders> Orders { get; set; }

    }
}
