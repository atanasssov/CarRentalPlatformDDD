namespace CarRentalPlatform.Domain.Exceptions
{
    public abstract class BaseDomainException : Exception
    {
        private string? message;

        public new string Message
        {
            // returns this.message if it's not null, otherwise, it returns the Message property from the base class (Exception).
            get => this.message ?? base.Message;
            set => this.message = value;
        }
    }
}
