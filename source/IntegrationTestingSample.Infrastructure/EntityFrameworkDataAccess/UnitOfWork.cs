namespace IntegrationTestingSample.Infrastructure.EntityFrameworkDataAccess
{
    using System.Threading.Tasks;
    using System;
    using IntegrationTestingSample.Application.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IntegrationTestingSampleContext context;

        public UnitOfWork(IntegrationTestingSampleContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            int affectedRows = await context.SaveChangesAsync();
            return affectedRows;
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}