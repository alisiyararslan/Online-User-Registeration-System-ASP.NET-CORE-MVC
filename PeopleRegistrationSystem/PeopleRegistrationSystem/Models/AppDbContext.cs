using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PeopleRegistrationSystem.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//unique key usage
        {

            modelBuilder.Entity<User>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
            .HasIndex(c => c.IdentificationNumber)
                .IsUnique();

            
        }

        private DbSet<User> _user { get; set; }

        public DbSet<User> Users { get => _user; set => _user = value; }
    }
}
