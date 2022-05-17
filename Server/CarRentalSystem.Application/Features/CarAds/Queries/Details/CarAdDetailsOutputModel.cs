﻿namespace CarRentalSystem.Application.Features.CarAds.Queries.Details
{
    using AutoMapper;
    using CarRentalSystem.Application.Features.CarAds.Queries.Common;
    using CarRentalSystem.Application.Features.Dealers.Queries.Common;
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Models.CarAds;

    public class CarAdDetailsOutputModel : CarAdOutputModel
    {
        public bool HasClimateControl { get; set; }

        public int NumberOfSeats { get; set; }

        public string TransmissionType { get; set; } = default!;

        public DealerOutputModel Dealer { get; set; } = default!;

        public override void Mapping(Profile mapper)
            => mapper
                .CreateMap<CarAd, CarAdDetailsOutputModel>()
                .IncludeBase<CarAd, CarAdOutputModel>()
                .ForMember(c => c.HasClimateControl, cfg => cfg
                    .MapFrom(c => c.Options.HasClimateControl))
                .ForMember(c => c.NumberOfSeats, cfg => cfg
                    .MapFrom(c => c.Options.NumberOfSeats))
                .ForMember(c => c.TransmissionType, cfg => cfg
                    .MapFrom(c => Enumeration.NameFromValue<TransmissionType>(
                        c.Options.TransmitionType.Value)));
    }
}
