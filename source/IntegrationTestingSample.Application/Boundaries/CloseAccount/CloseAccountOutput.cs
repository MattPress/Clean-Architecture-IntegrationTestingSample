namespace IntegrationTestingSample.Application.Boundaries.CloseAccount
{
    using System;
    using IntegrationTestingSample.Domain.Accounts;

    public sealed class CloseAccountOutput
    {
        public Guid AccountId { get; }

        public CloseAccountOutput(IAccount account)
        {
            AccountId = account.Id;
        }
    }
}