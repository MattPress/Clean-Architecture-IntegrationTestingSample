namespace IntegrationTestingSample.WebApi.UseCases.V1.Withdraw
{
    using IntegrationTestingSample.Application.Boundaries.Withdraw;
    using IntegrationTestingSample.WebApi.Models.V1.Withdraw;
    using Microsoft.AspNetCore.Mvc;

    public sealed class WithdrawPresenter : IOutputPort
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

        public void Default(WithdrawOutput withdrawOutput)
        {
            var withdrawResponse = new WithdrawResponse
            {
                Amount = withdrawOutput.Transaction.Amount,
                Description = withdrawOutput.Transaction.Description,
                TransactionDate = withdrawOutput.Transaction.TransactionDate,
                UpdateBalance = withdrawOutput.UpdatedBalance
            };
            ViewModel = new ObjectResult(withdrawResponse);
        }
    }
}