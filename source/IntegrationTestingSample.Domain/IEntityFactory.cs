namespace IntegrationTestingSample.Domain
{
    using System;
    using IntegrationTestingSample.Domain.Accounts;
    using IntegrationTestingSample.Domain.Customers;
    using IntegrationTestingSample.Domain.ValueObjects;

    public interface IEntityFactory
    {
        ICustomer NewCustomer(SSN ssn, Name name);
        IAccount NewAccount(ICustomer customer);
        ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate);
        IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate);
    }
}