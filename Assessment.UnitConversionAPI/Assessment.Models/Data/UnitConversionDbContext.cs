using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assessment.Models.Data
{
    public class UnitConversionDbContext : DbContext
    {
        public UnitConversionDbContext(DbContextOptions<UnitConversionDbContext> options) : base(options) { }
        public DbSet<UnitTypes> UnitTypes { get; set; }
        public DbSet<UnitDetails> UnitDetails { get; set; }
        //public DbSet<UnitConversionRates> ConversionRates { get; set; }
        public DbSet<ConversionHistory> ConversionHistories { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UnitConversionRates>()
        //        .HasOne(e => e.Target)
        //        .WithOne()
        //        .OnDelete(DeleteBehavior.Restrict);

        //    modelBuilder.Entity<UnitConversionRates>()
        //        .HasOne(e => e.Source)
        //        .WithOne()
        //        .OnDelete(DeleteBehavior.Restrict);
        //}
    }
}
