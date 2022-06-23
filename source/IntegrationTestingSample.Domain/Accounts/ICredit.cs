namespace IntegrationTestingSample.Domain.Accounts
{
    using IntegrationTestingSample.Domain.ValueObjects;

    public interface ICredit : IEntity
    {
        PositiveMoney Sum(PositiveMoney amount);
    }
}