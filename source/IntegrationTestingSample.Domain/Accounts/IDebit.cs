namespace IntegrationTestingSample.Domain.Accounts
{
    using IntegrationTestingSample.Domain.ValueObjects;

    public interface IDebit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}