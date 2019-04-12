using Microsoft.EntityFrameworkCore;

namespace FakeAndReal
{
    public class AppContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }

        private string ConnectionString = "Server=lenovo\\sqlexpress;Database=sandbox;Trusted_Connection=true;MultipleActiveResultsets=true";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
