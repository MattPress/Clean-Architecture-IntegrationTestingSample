namespace IntegrationTestingSample.WebApi.Models.V1.Register
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;
    using IntegrationTestingSample.WebApi.Models.ViewModels;

    /// <summary>
    /// The response for Registration
    /// </summary>
    public sealed class RegisterResponse
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
        public List<AccountDetailsModel> Accounts { get; set; }
    }
}