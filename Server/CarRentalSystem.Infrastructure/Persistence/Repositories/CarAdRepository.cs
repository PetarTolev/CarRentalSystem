namespace CarRentalSystem.Infrastructure.Persistence.Repositories
{
    using AutoMapper;
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Features.CarAds;
    using CarRentalSystem.Application.Features.CarAds.Queries.Categories;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Application.Features.CarAds.Queries.Details;
    using CarRentalSystem.Domain.Models.CarAds;
    using CarRentalSystem.Domain.Models.Dealers;
    using CarRentalSystem.Domain.Specifications;
    using CarRentalSystem.Infrastructure.Common;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CarAdRepository : DataRepository<CarAd>, ICarAdRepository
    {
        private readonly IMapper mapper;

        public CarAdRepository(CarRentalDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<CarAd> FindById(
            int id,
            CancellationToken cancellationToken = default)
            => await this
                .All()
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

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

        public async Task<IEnumerable<GetCarAdCategoryOutputModel>> GetCarAdCategories(
            CancellationToken cancellationToken = default)
        {
            var categories = await this.mapper
                .ProjectTo<GetCarAdCategoryOutputModel>(this.Data.Categories)
                .ToDictionaryAsync(c => c.Id, cancellationToken);

            var carAdsPerCategory = await this.AllAvailable()
                .GroupBy(c => c.Category.Id)
                .Select(gr => new
                {
                    CategoryId = gr.Key,
                    TotalCarAds = gr.Count()
                })
                .ToListAsync(cancellationToken);

            carAdsPerCategory.ForEach(c => categories[c.CategoryId].TotalCarAds = c.TotalCarAds);

            return categories.Values;
        }

        public async Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CarAdsSortOrder carAdsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await this.mapper
                .ProjectTo<TOutputModel>(this
                    .GetCarAdsQuery(carAdSpecification, dealerSpecification)
                    .Sort(carAdsSortOrder))
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take);

        public async Task<int> Total(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CancellationToken cancellationToken = default)
            => await this
                .GetCarAdsQuery(carAdSpecification, dealerSpecification)
                .CountAsync(cancellationToken);

        public async Task<CarAdDetailsOutputModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default)
            => await this.mapper
                .ProjectTo<CarAdDetailsOutputModel>(this
                    .AllAvailable()
                    .Where(c => c.Id == id))
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<Result> ChangeAvailability(
            int id,
            CancellationToken cancellationToken = default)
        {
            var carAd = await this.FindById(id, cancellationToken);

            carAd.ChangeAvailability();

            await this.Save(carAd, cancellationToken);

            return Result.Success;
        }

        public async Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default)
        {
            var carAd = await this.FindById(id, cancellationToken);

            if (carAd == null)
            {
                return false;
            }

            this.Data.CarAds.Remove(carAd);

            await this.Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        private IQueryable<CarAd> AllAvailable()
            => this
                .All()
                .Where(car => car.IsAvailable);

        private IQueryable<CarAd> GetCarAdsQuery(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification)
            => this
                .Data
                .Dealers
                .Where(dealerSpecification)
                .SelectMany(d => d.CarAds)
                .Where(carAdSpecification);
    }
}
