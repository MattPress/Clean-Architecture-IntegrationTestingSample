namespace IntegrationTestingSample.WebApi.UseCases.V1.GetCustomerDetails
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using IntegrationTestingSample.WebApi.Models.ViewModels;

    /// <summary>
    /// The Customer Details
    /// </summary>
    public sealed class GetCustomerDetailsResponse
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Required]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// SSN
        /// </summary>
        [Required]
        public string SSN { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Accounts
        /// </summary>
        [Required]
        public IList<AccountDetailsModel> Accounts { get; set; }
    }
}