namespace IntegrationTestingSample.WebApi.Extensions
{
    using Microsoft.Extensions.DependencyInjection;

    public static class UserInterfaceV1Extensions
    {
        public static IServiceCollection AddPresentersV1(this IServiceCollection services)
        {
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter, IntegrationTestingSample.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.CloseAccount.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.CloseAccount.CloseAccountPresenter>());
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.Deposit.DepositPresenter, IntegrationTestingSample.WebApi.UseCases.V1.Deposit.DepositPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Deposit.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.Deposit.DepositPresenter>());
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter, IntegrationTestingSample.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.GetAccountDetails.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.GetAccountDetails.GetAccountDetailsPresenter>());
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter, IntegrationTestingSample.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.GetCustomerDetails.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.GetCustomerDetails.GetCustomerDetailsPresenter>());
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.Register.RegisterPresenter, IntegrationTestingSample.WebApi.UseCases.V1.Register.RegisterPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Register.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.Register.RegisterPresenter>());
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.Withdraw.WithdrawPresenter, IntegrationTestingSample.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Withdraw.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.Withdraw.WithdrawPresenter>());
            services.AddScoped<IntegrationTestingSample.WebApi.UseCases.V1.Transfer.TransferPresenter, IntegrationTestingSample.WebApi.UseCases.V1.Transfer.TransferPresenter>();
            services.AddScoped<IntegrationTestingSample.Application.Boundaries.Transfer.IOutputPort>(x => x.GetRequiredService<IntegrationTestingSample.WebApi.UseCases.V1.Transfer.TransferPresenter>());
            return services;
        }
    }
}