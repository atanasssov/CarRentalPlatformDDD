﻿using CarRentalPlatform.Domain.Common;
using CarRentalPlatform.Domain.Exceptions;

using static CarRentalPlatform.Domain.Models.ModelConstants.Options;

namespace CarRentalPlatform.Domain.Models.CarAds
{
    public class Options : ValueObject
    {
        internal Options(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
        {
            this.Validate(numberOfSeats);

            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;
            this.TransmissionType = transmissionType;
        }

        private Options(bool hasClimateControl, int numberOfSeats)
        {
            this.HasClimateControl = hasClimateControl;
            this.NumberOfSeats = numberOfSeats;

            this.TransmissionType = null!;
        }

        public bool HasClimateControl { get; }

        public int NumberOfSeats { get; }

        public TransmissionType TransmissionType { get; }

        private void Validate(int numberOfSeats)
            => Guard.AgainstOutOfRange<InvalidOptionsException>(
                numberOfSeats,
                MinNumberOfSeats,
                MaxNumberOfSeats,
                nameof(this.NumberOfSeats));
    }
}
