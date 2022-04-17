namespace CarRentalSystem.Application.Features.CarAds.Queries.Categories
{
    using CarRentalSystem.Application.Mapping;
    using CarRentalSystem.Domain.Models.CarAds;

    public class GetCarAdCategoryOutputModel : IMapFrom<Category>
    {
        public int Id { get; }

        public string Name { get; } = default!;

        public string Description { get; } = default!;

        public int TotalCarAds { get; set; }
    }
}
