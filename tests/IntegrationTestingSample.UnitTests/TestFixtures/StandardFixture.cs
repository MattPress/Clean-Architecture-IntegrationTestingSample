namespace IntegrationTestingSample.UnitTests.TestFixtures
{
    using IntegrationTestingSample.Infrastructure.InMemoryDataAccess.Repositories;
    using IntegrationTestingSample.Infrastructure.InMemoryDataAccess;

    public sealed class StandardFixture
    {
        public EntityFactory EntityFactory { get; }
        public IntegrationTestingSampleContext Context { get; }
        public AccountRepository AccountRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public StandardFixture()
        {
            Context = new IntegrationTestingSampleContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
        }
    }
}