namespace CarRentalSystem.Application.Features.CarAds.Commands.Common
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.Dealers;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class ChangeCarAdCommandExtensions
    {
        public static async Task<Result> DealerHasCarAd(
            this ICurrentUser currentUser,
            int carAdId,
            IDealerRepository dealerRepository,
            CancellationToken cancellationToken = default)
        {
            var dealerId = await dealerRepository.GetDealerId(
                currentUser.UserId,
                cancellationToken);

            var dealerHasCarAd = await dealerRepository.HasCarAd(
                dealerId,
                carAdId,
                cancellationToken);

            return dealerHasCarAd
                ? Result.Success
                : "You cannot edit this car ad.";
        }
    }
}
