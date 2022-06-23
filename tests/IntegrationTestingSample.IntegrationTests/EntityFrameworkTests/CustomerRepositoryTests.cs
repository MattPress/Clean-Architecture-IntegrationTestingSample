namespace IntegrationTestingSample.IntegrationTests.EntityFrameworkTests
{
    using System.Linq;
    using System.Threading.Tasks;
    using System;
    using IntegrationTestingSample.Domain.Customers;
    using IntegrationTestingSample.Domain.ValueObjects;
    using IntegrationTestingSample.Domain;
    using IntegrationTestingSample.Infrastructure.EntityFrameworkDataAccess;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public sealed class CustomerRepositoryTests
    {
        [Fact]
        public async Task Add_ChangesDatabase()
        {
            var options = new DbContextOptionsBuilder<IntegrationTestingSampleContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            var factory = new EntityFactory();

            var customer = factory.NewCustomer(
                new SSN("198608177955"),
                new Name("Ivan Paulovich"));

            using(var context = new IntegrationTestingSampleContext(options))
            {
                context.Database.EnsureCreated();

                var repository = new CustomerRepository(context);
                await repository.Add(customer);

                Assert.Equal(2, context.Customers.Count());
            }
        }

        [Fact]
        public async Task Get_ReturnsCustomer()
        {
            var options = new DbContextOptionsBuilder<IntegrationTestingSampleContext>()
                .UseInMemoryDatabase(databaseName: "test_database")
                .Options;

            ICustomer customer = null;

            using(var context = new IntegrationTestingSampleContext(options))
            {
                context.Database.EnsureCreated();

                var repository = new CustomerRepository(context);
                customer = await repository.Get(new Guid("197d0438-e04b-453d-b5de-eca05960c6ae"));

                Assert.NotNull(customer);
            }

        }
    }
}