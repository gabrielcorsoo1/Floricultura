using Greenhouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenhouse.Data
{
    public class GreenhouseDbContext(DbContextOptions<GreenhouseDbContext> options) : DbContext(options)
    {
        public DbSet<Plant> Plants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>().ToTable("Plant");
        }
    }

}
