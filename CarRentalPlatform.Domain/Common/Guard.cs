using CarRentalPlatform.Domain.Exceptions;
using CarRentalPlatform.Domain.Models;

namespace CarRentalPlatform.Domain.Common
{
    // Class used for validations
    public static class Guard
    {
        // Ensures a string is not null or empty
        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null ot empty.");
        }

        // Ensures a string's length is within the specified range
        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        // Ensures an integer is within the specified range
        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        // Ensures a decimal is within the specified range
        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        // Ensures a URL is well-formed and within the maximum length
        public static void ForValidUrl<TException>(string url, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (url.Length <= ModelConstants.Common.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }

        // Ensures an actual value does not equal an unexpected value
        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        // Throws an exception of the specified type with the given error message.
        private static void ThrowException<TException>(string message)
             where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Message = message
            };

            throw exception;
        }
    }
}
