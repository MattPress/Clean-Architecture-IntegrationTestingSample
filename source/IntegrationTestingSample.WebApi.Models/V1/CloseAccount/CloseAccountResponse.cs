namespace IntegrationTestingSample.WebApi.Models.V1.CloseAccount
{
    using System.ComponentModel.DataAnnotations;
    using System;

    /// <summary>
    /// Close Account Response
    /// </summary>
    public sealed class CloseAccountResponse
    {
        /// <summary>
        /// Account ID
        /// </summary>
        [Required]
        public Guid AccountId { get; set; }
    }
}