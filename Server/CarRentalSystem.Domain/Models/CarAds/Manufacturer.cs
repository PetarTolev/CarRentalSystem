﻿namespace CarRentalSystem.Domain.Models.CarAds
{
    using CarRentalSystem.Domain.Common;
    using CarRentalSystem.Domain.Exceptions;
    using static ModelConstants.Common;

    public class Manufacturer : Entity<int>
    {
        public Manufacturer(string name)
        {
            this.Validate(name);

            this.Name = name;
        }

        public string Name { get; }

        private void Validate(string name)
            => Guard.ForStringLength<InvalidCarAdException>(
                name,
                MinNameLength,
                MaxUrlLength,
                nameof(this.Name));
    }
}