namespace IntegrationTestingSample.Application.UseCases
{
    using System.Threading.Tasks;
    using IntegrationTestingSample.Application.Boundaries.CloseAccount;
    using IntegrationTestingSample.Application.Repositories;
    using IntegrationTestingSample.Domain.Accounts;

    public sealed class CloseAccount : IUseCase
    {
        private readonly IOutputPort _outputHandler;
        private readonly IAccountRepository _accountRepository;

        public CloseAccount(
            IOutputPort outputHandler,
            IAccountRepository accountRepository)
        {
            _outputHandler = outputHandler;
            _accountRepository = accountRepository;
        }

        public async Task Execute(CloseAccountInput closeAccountInput)
        {
            IAccount account = await _accountRepository.Get(closeAccountInput.AccountId);
            if (account == null)
            {
                _outputHandler.Error($"The account {closeAccountInput.AccountId} does not exist or is already closed.");
                return;
            }

            if (account.IsClosingAllowed())
            {
                await _accountRepository.Delete(account);
            }

            var closeAccountOutput = new CloseAccountOutput(account);
            _outputHandler.Default(closeAccountOutput);
        }
    }
}