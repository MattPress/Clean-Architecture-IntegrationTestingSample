namespace IntegrationTestingSample.WebApi.Extensions
{
    using IntegrationTestingSample.Application.Repositories;
    using IntegrationTestingSample.Application.Services;
    using IntegrationTestingSample.Domain;
    using IntegrationTestingSample.Infrastructure.InMemoryDataAccess.Repositories;
    using IntegrationTestingSample.Infrastructure.InMemoryDataAccess;
    using Microsoft.Extensions.DependencyInjection;

    public static class InMemoryInfrastructureExtensions
    {
        public static IServiceCollection AddInMemoryPersistence(this IServiceCollection services)
        {
            services.AddScoped<IEntityFactory, EntityFactory>();

            services.AddSingleton<IntegrationTestingSampleContext, IntegrationTestingSampleContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}