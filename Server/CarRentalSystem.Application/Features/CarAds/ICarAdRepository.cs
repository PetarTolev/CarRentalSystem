namespace CarRentalSystem.Application.Features.CarAds
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.CarAds.Queries.Categories;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Domain.Models.CarAds;
    using CarRentalSystem.Domain.Models.Dealers;
    using CarRentalSystem.Domain.Specifications;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface ICarAdRepository : IRepository<CarAd>
    {
        Task<CarAd> FindById(
            int id,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<TOutputModel>> GetCarAdListings<TOutputModel>(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CarAdsSortOrder carAdsSortOrder,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default);

        Task<int> Total(
            Specification<CarAd> carAdSpecification,
            Specification<Dealer> dealerSpecification,
            CancellationToken cancellationToken = default);

        Task<Result> ChangeAvailability(
            int id,
            CancellationToken cancellationToken = default);

        Task<Category> GetCategory(
            int categoryId,
            CancellationToken cancellationToken = default);

        Task<Manufacturer> GetManufacturer(
            string manufacturer,
            CancellationToken cancellationToken = default);

        Task<IEnumerable<GetCarAdCategoryOutputModel>> GetCarAdCategories(
            CancellationToken cancellationToken = default);

        Task<bool> Delete(
            int id,
            CancellationToken cancellationToken = default);
    }
}
