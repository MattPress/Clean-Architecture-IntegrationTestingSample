namespace IntegrationTestingSample.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV2Extensions
    {
        public static IServiceCollection AddPresentersV2(this IServiceCollection services)
        {
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2, IntegrationTestingSample.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2>();

            services.AddTransient(ctx =>
                new UseCases.V2.GetAccountDetails.AccountsController(
                    new Application.UseCases.GetAccountDetails(
                        ctx.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2>(),
                        ctx.GetRequiredService<Application.Repositories.IAccountRepository>()
                    ),
                    ctx.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V2.GetAccountDetails.GetAccountDetailsPresenterV2>()
                )
            );

            return services;
        }
    }
}