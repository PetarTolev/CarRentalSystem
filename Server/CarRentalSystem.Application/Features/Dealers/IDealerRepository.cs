namespace CarRentalSystem.Application.Features.Dealers
{
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.Dealers.Queries.Common;
    using CarRentalSystem.Application.Features.Dealers.Queries.Details;
    using CarRentalSystem.Domain.Models.Dealers;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDealerRepository : IRepository<Dealer>
    {
        Task<Dealer> FindByUser(
            string userId,
            CancellationToken cancellationToken = default);

        Task<int> GetDealerId(
            string userId,
            CancellationToken cancellationToken = default);

        Task<DealerDetailsOutputModel> GetDetails(
            int id,
            CancellationToken cancellationToken = default);

        Task<bool> HasCarAd(
            int dealerId,
            int carAdId,
            CancellationToken cancellationToken = default);

        Task<DealerOutputModel> GetDetailsByCarAdId(
            int carAdId,
            CancellationToken cancellationToken = default);
    }
}
