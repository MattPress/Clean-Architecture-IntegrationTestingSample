namespace IntegrationTestingSample.WebApi.UseCases.V2.GetAccountDetails
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using IntegrationTestingSample.Application.Boundaries.GetAccountDetails;
    using IntegrationTestingSample.WebApi.Extensions.FeatureFlags;
    using IntegrationTestingSample.WebApi.Models.V2.GetAccountDetails;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.FeatureManagement.Mvc;

    [FeatureGate(Features.GetAccountDetailsV2)]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AccountsController : ControllerBase
    {
        private readonly IUseCase _getAccountDetailsUseCase;
        private readonly GetAccountDetailsPresenterV2 _presenter;

        public AccountsController(
            IUseCase getAccountDetailsUseCase,
            GetAccountDetailsPresenterV2 presenter)
        {
            _getAccountDetailsUseCase = getAccountDetailsUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Get an account details
        /// </summary>
        [HttpGet("{AccountId}", Name = "GetAccountV2")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute][Required] GetAccountDetailsRequestV2 request)
        {
            var getAccountDetailsInput = new GetAccountDetailsInput(request.AccountId);
            await _getAccountDetailsUseCase.Execute(getAccountDetailsInput);
            return _presenter.ViewModel;
        }
    }
}