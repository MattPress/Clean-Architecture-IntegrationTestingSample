namespace IntegrationTestingSample.Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Collections.Generic;
    using IntegrationTestingSample.Domain.Customers;
    using IntegrationTestingSample.Domain.ValueObjects;

    public class Customer : IntegrationTestingSample.Domain.Customers.Customer
    {
        protected Customer() { }

        public Customer(SSN ssn, Name name)
        {
            Id = Guid.NewGuid();
            SSN = ssn;
            Name = name;
        }

        public void LoadAccounts(IEnumerable<Guid> accounts)
        {
            Accounts = new AccountCollection();
            Accounts.Add(accounts);
        }
    }
}