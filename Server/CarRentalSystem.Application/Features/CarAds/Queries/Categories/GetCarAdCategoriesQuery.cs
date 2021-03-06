namespace CarRentalSystem.Application.Features.CarAds.Queries.Categories
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetCarAdCategoriesQuery : IRequest<IEnumerable<GetCarAdCategoryOutputModel>>
    {
        public class GetCarAdCategoriesQueryHandler : IRequestHandler<
            GetCarAdCategoriesQuery,
            IEnumerable<GetCarAdCategoryOutputModel>>
        {
            private readonly ICarAdRepository carAdRepository;

            public GetCarAdCategoriesQueryHandler(ICarAdRepository carAdRepository)
                => this.carAdRepository = carAdRepository;

            public async Task<IEnumerable<GetCarAdCategoryOutputModel>> Handle(
                GetCarAdCategoriesQuery request,
                CancellationToken cancellationToken)
                => await this.carAdRepository.GetCarAdCategories(cancellationToken);
        }
    }
}
