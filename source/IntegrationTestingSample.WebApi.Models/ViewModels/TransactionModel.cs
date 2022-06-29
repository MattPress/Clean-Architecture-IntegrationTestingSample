namespace IntegrationTestingSample.WebApi.Models.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Transaction
    /// </summary>
    public sealed class TransactionModel
    {
        /// <summary>
        /// Amount
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
    }
}