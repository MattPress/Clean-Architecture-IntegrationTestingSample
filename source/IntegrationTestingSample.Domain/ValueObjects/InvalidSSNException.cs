namespace IntegrationTestingSample.Domain.ValueObjects
{
    internal sealed class InvalidSSNException : DomainException
    {
        internal InvalidSSNException(string message) : base(message) { }
    }
}