namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Exceptions;
    using System;
    using static ModelConstants.Options;

    public class Options
    {
        internal Options(
            bool hasClimateControl,
            int numberOfSeats,
            TransmitionType transmitionType)
        {
            this.Validate(numberOfSeats);

            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;
            this.TransmitionType = transmitionType;
        }

        public bool HasClimateControl { get; }

        public int NumberOfSeats { get; }

        public TransmitionType TransmitionType { get; }

        private void Validate(int numberOfSeats)
            => Guard.AgainstOutOfRange<InvalidCarAdException>(
                numberOfSeats,
                MinNumberOfSeats,
                MaxNumberOfSeats,
                nameof(this.NumberOfSeats));
    }
}
