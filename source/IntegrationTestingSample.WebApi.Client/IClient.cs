using System;
using System.Threading;
using System.Threading.Tasks;
using IntegrationTestingSample.WebApi.Models.V1.CloseAccount;
using IntegrationTestingSample.WebApi.Models.V1.Deposit;
using IntegrationTestingSample.WebApi.Models.V1.GetAccountDetails;
using IntegrationTestingSample.WebApi.Models.V1.GetCustomerDetails;
using IntegrationTestingSample.WebApi.Models.V1.Register;
using IntegrationTestingSample.WebApi.Models.V1.Transfer;
using IntegrationTestingSample.WebApi.Models.V1.Withdraw;
using IntegrationTestingSample.WebApi.Models.V2.GetAccountDetails;
using IntegrationTestingSample.WebApi.UseCases.V1.GetCustomerDetails;
using Refit;

namespace IntegrationTestingSample.WebApi.Client
{
    public interface IClient
    {
        [Delete("/api/v1/accounts/{request.AccountId}")]
        Task<IApiResponse<CloseAccountResponse>> CloseAccount(
            [Body] CloseAccountRequest request,
            CancellationToken cancellationToken = default);

        [Patch("/api/v1/accounts/deposit")]
        Task<IApiResponse<DepositResponse>> Deposit(
            [Body] DepositRequest request,
            CancellationToken cancellationToken = default);

        [Get("/api/v1/accounts/{request.AccountId}")]
        Task<IApiResponse<GetAccountDetailsResponse>> GetAccountDetails(
            GetAccountDetailsRequest request,
            CancellationToken cancellationToken = default);

        [Get("/api/v1/customers/{request.CustomerId}")]
        Task<IApiResponse<GetCustomerDetailsResponse>> GetCustomer(
            GetCustomerDetailsRequest request,
            CancellationToken cancellationToken = default);

        [Post("/api/v1/customers")]
        Task<IApiResponse<RegisterResponse>> RegisterCustomer(
            [Body] RegisterRequest request,
            CancellationToken cancellationToken = default);

        [Patch("/api/v1/accounts/transfer")]
        Task<IApiResponse<TransferResponse>> Transfer(
            [Body] TransferRequest request,
            CancellationToken cancellationToken = default);

        [Patch("/api/v1/accounts/withdraw")]
        Task<IApiResponse<WithdrawResponse>> Withdraw(
            [Body] WithdrawRequest request,
            CancellationToken cancellationToken = default);
        
        [Get("/api/v2/accountsv2/{request.AccountId}")]
        Task<IApiResponse<GetAccountDetailsResponseV2>> GetAccountDetails(
            GetAccountDetailsRequestV2 request,
            CancellationToken cancellationToken = default);
    }
}
