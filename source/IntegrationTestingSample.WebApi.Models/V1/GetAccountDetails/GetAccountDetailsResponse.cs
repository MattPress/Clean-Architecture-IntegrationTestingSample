namespace IntegrationTestingSample.WebApi.Models.V1.GetAccountDetails
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using IntegrationTestingSample.WebApi.Models.ViewModels;

    /// <summary>
    /// Get Account Details
    /// </summary>
    public sealed class GetAccountDetailsResponse
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
        public IList<TransactionModel> Transactions { get; set; }
    }
}