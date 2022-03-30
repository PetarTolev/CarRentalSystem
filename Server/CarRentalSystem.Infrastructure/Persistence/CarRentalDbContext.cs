namespace CarRentalSystem.Infrastructure.Persistence
{
    using CarRentalSystem.Domain.Models.CarAds;
    using CarRentalSystem.Domain.Models.Dealers;
    using Microsoft.EntityFrameworkCore;
    using System.Reflection;

    internal class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
            : base(options)
        {
        }

        public DbSet<CarAd> CarAds { get; set; } = default!;

        public DbSet<Category> Categories { get; set; } = default!;

        public DbSet<Manufacturer> Manufacturers { get; set; } = default!;

        public DbSet<Dealer> Dealers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
