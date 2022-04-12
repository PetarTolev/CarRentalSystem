namespace CarRentalSystem.Application.Features.CarAds
{
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.CarAds.Queries.Search;
    using CarRentalSystem.Domain.Models.CarAds;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICarAdRepository : IRepository<CarAd>
    {
        Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            string? manufacturer = default, 
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId, 
            CancellationToken cancellationToken = default);

        Task<Manufacturer> GetManufacturer(
            string manufacturer, 
            CancellationToken cancellationToken = default);
    }
}
