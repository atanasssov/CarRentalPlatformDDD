﻿using CarRentalPlatform.Domain.Models.CarAds;

using FluentAssertions;
using Xunit;

namespace CarRentalPlatform.Domain.Common
{
    public class ValueObjectSpecs
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new Options(true, 2, TransmissionType.Automatic);
            var second = new Options(true, 2, TransmissionType.Automatic);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new Options(true, 2, TransmissionType.Automatic);
            var second = new Options(true, 2, TransmissionType.Manual);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}
