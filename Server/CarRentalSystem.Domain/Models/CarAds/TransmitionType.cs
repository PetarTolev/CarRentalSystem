﻿namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Common;

    public class TransmitionType : Enumeration
    {
        public static readonly TransmitionType Manual = new TransmitionType(1, nameof(Manual));
        public static readonly TransmitionType Automatic = new TransmitionType(2, nameof(Automatic));

        public TransmitionType(int value)
            : this(value, FromValue<TransmitionType>(value).Name)
        {
        }

        public TransmitionType(int value, string name)
            : base(value, name)
        {
        }
    }
}