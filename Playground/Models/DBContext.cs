using Microsoft.EntityFrameworkCore;
using Playground.Models;

namespace Playground
{
    public class PlaygroundContext : DbContext
    {
        public PlaygroundContext(DbContextOptions<PlaygroundContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<TaxOffice> TaxOffices { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Base> Base { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Manufacturer>().ToTable("Manufacturers");
            modelBuilder.Entity<Model>().ToTable("Models");
            modelBuilder.Entity<Color>().ToTable("Colors");
        }
    }
}
