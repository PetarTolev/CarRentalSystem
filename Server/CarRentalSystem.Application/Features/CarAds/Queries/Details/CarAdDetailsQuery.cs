namespace CarRentalSystem.Application.Features.CarAds.Queries.Details
{
    using CarRentalSystem.Application.Features.Dealers;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CarAdDetailsQuery : IRequest<CarAdDetailsOutputModel>
    {
        public int Id { get; set; }

        public class CarAdDetailsQueryHandler : IRequestHandler<CarAdDetailsQuery, CarAdDetailsOutputModel>
        {
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;

            public CarAdDetailsQueryHandler(
                ICarAdRepository carAdRepository,
                IDealerRepository dealerRepository)
            {
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<CarAdDetailsOutputModel> Handle(
                CarAdDetailsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdDetails = await this.carAdRepository.GetDetails(
                    request.Id,
                    cancellationToken);

                carAdDetails.Dealer = await this.dealerRepository.GetDetailsByCarAdId(
                    request.Id,
                    cancellationToken);

                return carAdDetails;
            }
        }
    }
}
