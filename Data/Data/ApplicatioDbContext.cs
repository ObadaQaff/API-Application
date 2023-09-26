using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Cars;
using MyApp.Domain.Users;

namespace MyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Car>Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e=>e.Name).IsRequired(false);

        }

    }

   
}
