namespace IntegrationTestingSample.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using IntegrationTestingSample.Domain.Accounts;
    using IntegrationTestingSample.Domain.ValueObjects;

    public class Credit : IntegrationTestingSample.Domain.Accounts.Credit
    {
        public Guid AccountId { get; protected set; }

        protected Credit() { }

        public Credit(IAccount account, PositiveMoney amountToDeposit, DateTime transactionDate)
        {
            this.AccountId = account.Id;
            this.Amount = amountToDeposit;
            this.TransactionDate = transactionDate;
        }
    }
}