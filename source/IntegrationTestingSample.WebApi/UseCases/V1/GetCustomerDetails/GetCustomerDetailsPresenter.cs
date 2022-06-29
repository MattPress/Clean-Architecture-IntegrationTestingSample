namespace IntegrationTestingSample.WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using IntegrationTestingSample.Application.Boundaries.GetCustomerDetails;
    using IntegrationTestingSample.WebApi.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public IActionResult ViewModel { get; private set; }

        public void Error(string message)
        {
            var problemDetails = new ProblemDetails()
            {
                Title = "An error occurred",
                Detail = message
            };

            ViewModel = new BadRequestObjectResult(problemDetails);
        }

        public void Default(GetCustomerDetailsOutput getCustomerDetailsOutput)
        {
            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();

            foreach (var account in getCustomerDetailsOutput.Accounts)
            {
                List<TransactionModel> transactions = new List<TransactionModel>();

                foreach (var item in account.Transactions)
                {
                    var transaction = new TransactionModel
                    {
                        Amount = item.Amount,
                        Description = item.Description,
                        TransactionDate = item.TransactionDate
                    };

                    transactions.Add(transaction);
                }

                accounts.Add(new AccountDetailsModel
                {
                    AccountId = account.AccountId,
                    CurrentBalance = account.CurrentBalance,
                    Transactions = transactions
                });
                    
            }

            var getCustomerDetailsResponse = new GetCustomerDetailsResponse
            {
                CustomerId = getCustomerDetailsOutput.CustomerId,
                SSN = getCustomerDetailsOutput.SSN,
                Name = getCustomerDetailsOutput.Name,
                Accounts = accounts
            };

            ViewModel = new OkObjectResult(getCustomerDetailsResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}