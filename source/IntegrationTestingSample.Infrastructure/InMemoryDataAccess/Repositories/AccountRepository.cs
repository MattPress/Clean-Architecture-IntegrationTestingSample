namespace IntegrationTestingSample.Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using IntegrationTestingSample.Application.Repositories;
    using IntegrationTestingSample.Domain.Accounts;

    public sealed class AccountRepository : IAccountRepository
    {
        private readonly IntegrationTestingSampleContext _context;

        public AccountRepository(IntegrationTestingSampleContext context)
        {
            _context = context;
        }

        public async Task Add(IAccount account, ICredit credit)
        {
            _context.Accounts.Add((InMemoryDataAccess.Account) account);
            _context.Credits.Add((InMemoryDataAccess.Credit) credit);
            await Task.CompletedTask;
        }

        public async Task Delete(IAccount account)
        {
            var accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            _context.Accounts.Remove(accountOld);

            await Task.CompletedTask;
        }

        public async Task<IAccount> Get(Guid id)
        {
            Account account = _context.Accounts
                .Where(e => e.Id == id)
                .SingleOrDefault();

            return await Task.FromResult<Account>(account);
        }

        public async Task Update(IAccount account, ICredit credit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            accountOld = (Account) account;
            await Task.CompletedTask;
        }

        public async Task Update(IAccount account, IDebit debit)
        {
            Account accountOld = _context.Accounts
                .Where(e => e.Id == account.Id)
                .SingleOrDefault();

            accountOld = (Account) account;
            await Task.CompletedTask;
        }
    }
}