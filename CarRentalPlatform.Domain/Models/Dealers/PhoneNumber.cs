using CarRentalPlatform.Domain.Common;
using CarRentalPlatform.Domain.Exceptions;

using static CarRentalPlatform.Domain.Models.ModelConstants.PhoneNumber;

namespace CarRentalPlatform.Domain.Models.Dealers
{
    public class PhoneNumber : ValueObject
    {
        internal PhoneNumber(string number)
        {
            this.Validate(number);

            if (!number.StartsWith(PhoneNumberFirstSymbol))
            {
                throw new InvalidPhoneNumberException($"Phone number must start with a '{PhoneNumberFirstSymbol}'.");
            }

            this.Number = number;
        }

        public string Number { get; }

        public static implicit operator string(PhoneNumber number) => number.Number;

        public static implicit operator PhoneNumber(string number) => new PhoneNumber(number);

        private void Validate(string phoneNumber)
            => Guard.ForStringLength<InvalidPhoneNumberException>(
                phoneNumber,
                MinPhoneNumberLength,
                MaxPhoneNumberLength,
                nameof(PhoneNumber));
    }
}
