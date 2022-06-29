namespace IntegrationTestingSample.WebApi.UseCases.V1.Deposit
{
    using IntegrationTestingSample.Application.Boundaries.Deposit;
    using IntegrationTestingSample.WebApi.Models.V1.Deposit;
    using Microsoft.AspNetCore.Mvc;

    public sealed class DepositPresenter : IOutputPort
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

        public void Default(DepositOutput depositOutput)
        {
            var depositResponse = new DepositResponse
            {
                Amount = depositOutput.Transaction.Amount,
                Description = depositOutput.Transaction.Description,
                TransactionDate = depositOutput.Transaction.TransactionDate,
                UpdateBalance = depositOutput.UpdatedBalance
            };
                
            ViewModel = new ObjectResult(depositResponse);
        }
    }
}