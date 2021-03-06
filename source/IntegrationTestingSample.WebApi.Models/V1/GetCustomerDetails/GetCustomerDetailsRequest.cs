namespace IntegrationTestingSample.WebApi.Models.V1.GetCustomerDetails
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// The Get Customer Details Request
    /// </summary>
    public sealed class GetCustomerDetailsRequest
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        [Required]
        public Guid CustomerId { get; set; }
    }
}