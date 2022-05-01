namespace CarRentalSystem.Application.Features.CarAds.Queries.Mine
{
    using CarRentalSystem.Application.Contracts;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Application.Features.Dealers;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class MineCarAdsQuery : CarAdsQuery, IRequest<MineCarAdsOutputModel>
    {
        public class MineCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<
            MineCarAdsQuery, 
            MineCarAdsOutputModel>
        {
            private readonly ICurrentUser currentUser;
            private readonly IDealerRepository dealerRepository;

            public MineCarAdsQueryHandler(
                ICurrentUser currentUser,
                IDealerRepository dealerRepository,
                ICarAdRepository carAdRepository)
                : base(carAdRepository)
            {
                this.currentUser = currentUser;
                this.dealerRepository = dealerRepository;
            }

            public async Task<MineCarAdsOutputModel> Handle(
                MineCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var dealerId = await this.dealerRepository.GetDealerId(
                    this.currentUser.UserId,
                    cancellationToken);

                var carAds = await base.GetCarAdListings<MineCarAdOutputModel>(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    onlyAvailable: false,
                    dealerId,
                    cancellationToken);

                return new MineCarAdsOutputModel(carAds, request.Page, totalPages);
            }
        }
    }
}
