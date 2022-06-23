namespace IntegrationTestingSample.Infrastructure.InMemoryDataAccess
{
    using System;
    using IntegrationTestingSample.Domain;
    using IntegrationTestingSample.Domain.Accounts;
    using IntegrationTestingSample.Domain.Customers;
    using IntegrationTestingSample.Domain.ValueObjects;

    public sealed class EntityFactory : IEntityFactory
    {
        public IAccount NewAccount(ICustomer customer)
        {
            var account = new Account(customer);
            return account;
        }

        public ICredit NewCredit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate)
        {
            var credit = new Credit(account, amountToDeposit, transactionDate);
            return credit;
        }

        public ICustomer NewCustomer(SSN ssn, Name name)
        {
            var customer = new Customer(ssn, name);
            return customer;
        }

        public IDebit NewDebit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate)
        {
            var debit = new Debit(account, amountToWithdraw, transactionDate);
            return debit;
        }
    }
}