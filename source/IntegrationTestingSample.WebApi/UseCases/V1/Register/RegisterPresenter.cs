namespace IntegrationTestingSample.WebApi.UseCases.V1.Register
{
    using System.Collections.Generic;
    using IntegrationTestingSample.Application.Boundaries.Register;
    using IntegrationTestingSample.WebApi.Models.V1.Register;
    using IntegrationTestingSample.WebApi.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc;

    public sealed class RegisterPresenter : IOutputPort
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

        public void Standard(RegisterOutput output)
        {
            var transactions = new List<TransactionModel>();

            foreach (var item in output.Account.Transactions)
            {
                var transaction = new TransactionModel
                {
                    Amount = item.Amount,
                    Description = item.Description,
                    TransactionDate = item.TransactionDate
                };

                transactions.Add(transaction);
            }

            var account = new AccountDetailsModel
            {
                AccountId = output.Account.AccountId,
                CurrentBalance = output.Account.CurrentBalance,
                Transactions = transactions
            };

            var accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            var registerResponse = new RegisterResponse
            {
                CustomerId = output.Customer.CustomerId,
                SSN = output.Customer.SSN,
                Name = output.Customer.Name,
                Accounts = accounts
            };
                

            ViewModel = new CreatedAtRouteResult(nameof(GetCustomerDetails.CustomersController.GetCustomer),
                //new
                //{
                //    customerId = registerResponse.CustomerId
                //},
                registerResponse);
        }
    }
}