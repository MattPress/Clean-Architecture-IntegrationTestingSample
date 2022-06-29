namespace IntegrationTestingSample.WebApi.Models.V1.Deposit
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// The response for a successfull Deposit
    /// </summary>
    public sealed class DepositResponse
    {
        /// <summary>
        /// Amount Deposited
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Transaction Date
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Updated Balance
        /// </summary>
        [Required]
        public decimal UpdateBalance { get; set; }
    }
}