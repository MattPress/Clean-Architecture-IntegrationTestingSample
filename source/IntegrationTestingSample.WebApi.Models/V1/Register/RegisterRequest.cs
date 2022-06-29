using System.ComponentModel.DataAnnotations;

namespace IntegrationTestingSample.WebApi.Models.V1.Register
{
    /// <summary>
    /// Registration Request
    /// </summary>
    public sealed class RegisterRequest
    {
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
        /// Initial Amount
        /// </summary>
        [Required]
        public decimal InitialAmount { get; set; }
    }
}