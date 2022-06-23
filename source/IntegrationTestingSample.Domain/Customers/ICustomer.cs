namespace IntegrationTestingSample.Domain.Customers
{
    using IntegrationTestingSample.Domain.Accounts;

    public interface ICustomer : IAggregateRoot
    {
        AccountCollection Accounts { get; }
        void Register(IAccount account);
    }
}