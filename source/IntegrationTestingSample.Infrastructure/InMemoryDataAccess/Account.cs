namespace IntegrationTestingSample.Infrastructure.InMemoryDataAccess
{
    using System;
    using System.Collections.Generic;
    using IntegrationTestingSample.Domain.Accounts;
    using IntegrationTestingSample.Domain.Customers;

    public class Account : IntegrationTestingSample.Domain.Accounts.Account
    {
        public Guid CustomerId { get; protected set; }

        protected Account() { }

        public Account(ICustomer customer)
        {
            Id = Guid.NewGuid();
            CustomerId = customer.Id;
        }

        public void Load(IList<Credit> credits, IList<Debit> debits)
        {
            Credits = new CreditsCollection();
            Credits.Add(credits);

            Debits = new DebitsCollection();
            Debits.Add(debits);
        }
    }
}