namespace IntegrationTestingSample.Application.Exceptions
{
    using IntegrationTestingSample.Domain;

    public sealed class InputValidationException : DomainException
    {
        public InputValidationException(string message) : base(message) { }
    }
}