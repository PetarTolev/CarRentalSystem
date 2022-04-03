namespace CarRentalSystem.Application.Features.CarAds
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Search;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICarAdRepository
    {
        Task<IEnumerable<CarAdListingModel>> GetCarAdListings(
            string? manufacturer = default, 
            CancellationToken cancellationToken = default);

        Task<int> Total(CancellationToken cancellationToken = default);
    }
}
