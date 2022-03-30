namespace CarRentalSystem.Web.Features
{
    using CarRentalSystem.Domain.Models.CarAds;
    using CarRentalSystem.Domain.Models.Dealers;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    internal class CarAdsController : ControllerBase
    {
        private static readonly Dealer Dealer = new Dealer("Dealer", "+123123123");

        public IEnumerable<CarAd> Get => Dealer
            .CarAds
            .Where(c => c.IsAvailable);
    }
}
