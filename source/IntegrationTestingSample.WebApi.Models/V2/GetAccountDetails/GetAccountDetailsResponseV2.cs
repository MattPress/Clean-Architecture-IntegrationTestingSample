namespace IntegrationTestingSample.WebApi.Models.V2.GetAccountDetails
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using IntegrationTestingSample.WebApi.Models.ViewModels;

    /// <summary>
    /// Get Account Details Response
    /// </summary>
    public sealed class GetAccountDetailsResponseV2
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