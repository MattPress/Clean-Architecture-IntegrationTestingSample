namespace IntegrationTestingSample.Infrastructure.EntityFrameworkDataAccess
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using IntegrationTestingSample.Application.Repositories;
    using IntegrationTestingSample.Domain.Customers;
    using Microsoft.EntityFrameworkCore;

    public sealed class CustomerRepository : ICustomerRepository
    {
        private readonly IntegrationTestingSampleContext _context;

        public CustomerRepository(IntegrationTestingSampleContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(ICustomer customer)
        {
            await _context.Customers.AddAsync((Customer) customer);
            await _context.SaveChangesAsync();
        }

        public async Task<ICustomer> Get(Guid id)
        {
            Customer customer = await _context.Customers
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync();

            if (customer == null)
                return null;

            var accounts = _context.Accounts
                .Where(e => e.CustomerId == id)
                .Select(e => e.Id)
                .ToList();

            customer.LoadAccounts(accounts);

            return customer;
        }

        public async Task Update(ICustomer customer)
        {
            _context.Customers.Update((Customer) customer);
            await _context.SaveChangesAsync();
        }
    }
}