namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using CarRentalSystem.Application.Features.CarAds;
    using CarRentalSystem.Application.Features.CarAds.Queries.Search;
    using CarRentalSystem.Domain.Models.CarAds;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CarAdRepository : DataRepository<CarAd>, ICarAdRepository
    {
        public CarAdRepository(CarRentalDbContext db)
            : base(db)
        {
        }

        public async Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            string? manufacturer = null,
            CancellationToken cancellationToken = default)
        {
            var query = this.AllAvailable();

            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                query = query
                    .Where(car => EF
                        .Functions
                        .Like(car.Manufacturer.Name, $"%{manufacturer}%"));
            }

            return await query
                .Select(car => new CarAdListingModel(
                    car.Id,
                    car.Manufacturer.Name,
                    car.Model,
                    car.ImageUrl,
                    car.Category.Name,
                    car.PricePerDay))
                .ToListAsync();
        }

        public async Task<int> Total(CancellationToken cancellationToken = default)
            => await this
                .AllAvailable()
                .CountAsync(cancellationToken);

        public async Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId, cancellationToken);

        public async Task<Manufacturer> GetManufacturer(
            string manufacturer,
            CancellationToken cancellationToken = default)
            => await this
                .Data
                .Manufacturers
                .FirstOrDefaultAsync(m => m.Name == manufacturer, cancellationToken);


        private IQueryable<CarAd> AllAvailable()
            => this
                .All()
                .Where(car => car.IsAvailable);
    }
}
