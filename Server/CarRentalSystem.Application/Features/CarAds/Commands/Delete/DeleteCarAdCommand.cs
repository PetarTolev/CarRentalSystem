namespace CarRentalSystem.Application.Features.CarAds.Commands.Delete
{
    using CarRentalSystem.Application.Common;
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.CarAds.Commands.Common;
    using CarRentalSystem.Application.Features.Dealers;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCarAdCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteCarAdCommandHandler : IRequestHandler<DeleteCarAdCommand, Result>
        {
            private readonly ICurrentUser currentUser;
            private readonly ICarAdRepository carAdRepository;
            private readonly IDealerRepository dealerRepository;

            public DeleteCarAdCommandHandler(
                ICurrentUser currentUser,
                ICarAdRepository carAdRepository,
                IDealerRepository dealerRepository)
            {
                this.currentUser = currentUser;
                this.carAdRepository = carAdRepository;
                this.dealerRepository = dealerRepository;
            }

            public async Task<Result> Handle(
                DeleteCarAdCommand request,
                CancellationToken cancellationToken)
            {
                var dealerHasCarAd = await this.currentUser.DealerHasCarAd(
                    request.Id,
                    this.dealerRepository,
                    cancellationToken);

                if (!dealerHasCarAd)
                {
                    return dealerHasCarAd;
                }

                return await this.carAdRepository.Delete(
                    request.Id,
                    cancellationToken);
            }
        }
    }
}
