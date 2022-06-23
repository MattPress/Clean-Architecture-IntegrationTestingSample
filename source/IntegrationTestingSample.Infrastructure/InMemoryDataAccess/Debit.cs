namespace IntegrationTestingSample.Infrastructure.InMemoryDataAccess
{
    using System;
    using IntegrationTestingSample.Domain.Accounts;
    using IntegrationTestingSample.Domain.ValueObjects;

    public class Debit : IntegrationTestingSample.Domain.Accounts.Debit
    {
        public Guid AccountId { get; protected set; }

        protected Debit() { }

        public Debit(IAccount account, PositiveMoney amountToWithdraw, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToWithdraw;
            this.TransactionDate = transactionDate;
        }
    }
}