namespace CarRentalSystem.Application.Features.CarAds.Queries.Search
{
    public class CarAdListingModel
    {
        public CarAdListingModel(
            int id,
            string manufacturer,
            string model,
            string imageUrl,
            string category,
            decimal pricePerDay)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.ImageUrl = imageUrl;
            this.Category = category;
            this.PrivePerDay = pricePerDay;
        }

        public int Id { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public decimal PrivePerDay { get; set; }
    }
}
