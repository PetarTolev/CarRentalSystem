namespace CarRentalSystem.Web.Features
{
    using Application.Contracts;
    using CarRentalSystem.Application;
    using Domain.Models.CarAds;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class CarAdsController : ControllerBase
    {
        private readonly IRepository<CarAd> carAds;
        private readonly IOptions<ApplicationSettings> settings;

        public CarAdsController(
            IRepository<CarAd> carAds,
            IOptions<ApplicationSettings> settings)
        {
            this.carAds = carAds;
            this.settings = settings;
        }

        [HttpGet]
        public object Get() => new
        {
            Settings = this.settings,
            CarAds = this.carAds
                .All()
                .Where(c => c.IsAvailable)
                .ToList()
        };
    }
}
