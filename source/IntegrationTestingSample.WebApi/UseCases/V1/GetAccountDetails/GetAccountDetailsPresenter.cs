namespace IntegrationTestingSample.WebApi.UseCases.V1.GetAccountDetails
{
    using System.Collections.Generic;
    using IntegrationTestingSample.Application.Boundaries.GetAccountDetails;
    using IntegrationTestingSample.WebApi.Models.V1.GetAccountDetails;
    using IntegrationTestingSample.WebApi.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public sealed class GetAccountDetailsPresenter : IOutputPort
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

        public void Default(GetAccountDetailsOutput getAccountDetailsOutput)
        {
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in getAccountDetailsOutput.Transactions)
            {
                var transaction = new TransactionModel
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    TransactionDate = item.TransactionDate
                };

                transactions.Add(transaction);
            }

            var getAccountDetailsResponse = new GetAccountDetailsResponse
            {
                AccountId = getAccountDetailsOutput.AccountId,
                CurrentBalance = getAccountDetailsOutput.CurrentBalance,
                Transactions = transactions
            };

            ViewModel = new OkObjectResult(getAccountDetailsResponse);
        }

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }
    }
}