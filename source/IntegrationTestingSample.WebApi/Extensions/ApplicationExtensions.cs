namespace IntegrationTestingSample.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.CloseAccount.IUseCase, IntegrationTestingSample.Application.UseCases.CloseAccount>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Deposit.IUseCase, IntegrationTestingSample.Application.UseCases.Deposit>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.GetAccountDetails.IUseCase, IntegrationTestingSample.Application.UseCases.GetAccountDetails>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.GetCustomerDetails.IUseCase, IntegrationTestingSample.Application.UseCases.GetCustomerDetails>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Register.IUseCase, IntegrationTestingSample.Application.UseCases.Register>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Withdraw.IUseCase, IntegrationTestingSample.Application.UseCases.Withdraw>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Transfer.IUseCase, IntegrationTestingSample.Application.UseCases.Transfer>();
            return services;
        }
    }
}