namespace IntegrationTestingSample.Infrastructure.InMemoryDataAccess
{
    using System.Threading.Tasks;
    using IntegrationTestingSample.Application.Services;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private IntegrationTestingSampleContext context;

        public UnitOfWork(IntegrationTestingSampleContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult<int>(0);
        }
    }
}