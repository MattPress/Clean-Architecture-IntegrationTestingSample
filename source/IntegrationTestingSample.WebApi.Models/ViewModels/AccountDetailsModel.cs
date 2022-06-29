namespace IntegrationTestingSample.WebApi.Models.ViewModels
{
    using System.Collections.Generic;
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Account Details
    /// </summary>
    public sealed class AccountDetailsModel
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
        
        /// <summary>
        /// Current Balance
        /// </summary>
        [Required]
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// Transactions
        /// </summary>
        [Required]
        public List<TransactionModel> Transactions { get; set; }
    }
}