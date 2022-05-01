namespace CarRentalSystem.Application.Features.CarAds.Commands.ChangeAvailability
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.Dealers;
    using CarRentalSystem.Application.Features.CarAds.Commands.Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChangeAvailabilityCommand : EntityCommand<int>, IRequest<Result>
    {
        public class ChangeAvailabilityCommandHandler : IRequestHandler<ChangeAvailabilityCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly IDealerRepository dealerRepository;
            private readonly ICarAdRepository carAdRepository;

            public ChangeAvailabilityCommandHandler(
                ICurrentUser currentUser,
                IDealerRepository dealerRepository,
                ICarAdRepository carAdRepository)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
                this.carAdRepository = carAdRepository;
            }

            public async Task<Result> Handle(
                ChangeAvailabilityCommand request,
                CancellationToken cancellationToken)
            {
                var dealerHasCarAd  = await this.currentUser.DealerHasCarAd(
                    request.Id,
                    this.dealerRepository,
                    cancellationToken);

                if (!dealerHasCarAd)
                {
                    return dealerHasCarAd;
                }

                return await this.carAdRepository.ChangeAvailability(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
