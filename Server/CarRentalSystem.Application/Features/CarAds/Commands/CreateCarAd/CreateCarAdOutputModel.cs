namespace CarRentalSystem.Application.Features.CarAds.Commands.CreateCarAd
{
    public class CreateCarAdOutputModel
    {
        internal CreateCarAdOutputModel(int carAdId)
            => CarAdId = carAdId;

        public int CarAdId { get; }
    }
}
