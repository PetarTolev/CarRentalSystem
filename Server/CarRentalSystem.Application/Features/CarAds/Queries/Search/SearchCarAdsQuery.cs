namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class SearchCarAdsQuery : CarAdsQuery, IRequest<SearchCarAdsOutputModel>
    {
        public class SearchCarAdsQueryHandler : CarAdsQueryHandler, IRequestHandler<
            SearchCarAdsQuery,
            SearchCarAdsOutputModel>
        {
            public SearchCarAdsQueryHandler(ICarAdRepository carAdRepository)
                : base(carAdRepository)
            {
            }

            public async Task<SearchCarAdsOutputModel> Handle(
                SearchCarAdsQuery request,
                CancellationToken cancellationToken)
            {
                var carAdListings = await base.GetCarAdListings<CarAdOutputModel>(
                    request,
                    cancellationToken: cancellationToken);

                var totalPages = await base.GetTotalPages(
                    request,
                    cancellationToken: cancellationToken);

                return new SearchCarAdsOutputModel(carAdListings, request.Page, totalPages);
            }
        }
    }
}
