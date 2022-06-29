namespace IntegrationTestingSample.WebApi.Models.V1.Withdraw
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public sealed class WithdrawResponse
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal UpdateBalance { get; set; }
    }
}