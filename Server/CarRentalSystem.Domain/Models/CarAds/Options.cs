namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Exceptions;
    using System;
    using static ModelConstants.Options;

    public class Options : ValueObject
    {
        internal Options(
            bool hasClimateControl,
            int numberOfSeats,
            TransmissionType transmitionType)
        {
            this.Validate(numberOfSeats);

            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;
            this.TransmitionType = transmitionType;
        }

        private Options(
            bool hasClimateControl,
            int numberOfSeats)
        {
            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;

            this.TransmitionType = default!;
        }

        public bool HasClimateControl { get; }

        public int NumberOfSeats { get; }

        public TransmissionType TransmitionType { get; }

        private void Validate(int numberOfSeats)
            => Guard.AgainstOutOfRange<InvalidCarAdException>(
                numberOfSeats,
                MinNumberOfSeats,
                MaxNumberOfSeats,
                nameof(this.NumberOfSeats));
    }
}
