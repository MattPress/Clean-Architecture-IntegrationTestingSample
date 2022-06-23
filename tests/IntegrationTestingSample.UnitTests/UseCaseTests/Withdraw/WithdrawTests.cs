namespace IntegrationTestingSample.UnitTests.UseCasesTests.Withdraw
{
    using System.Linq;
    using System.Threading.Tasks;
    using IntegrationTestingSample.Application.Boundaries.Withdraw;
    using IntegrationTestingSample.Application.UseCases;
    using IntegrationTestingSample.Domain.ValueObjects;
    using IntegrationTestingSample.Infrastructure.InMemoryDataAccess;
    using IntegrationTestingSample.UnitTests.TestFixtures;
    using Xunit;

    public sealed class WithdrawlTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;
        public WithdrawlTests(StandardFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(PositiveDataSetup))]
        public async Task Withdraw_Valid_Amount(
            decimal amount,
            decimal expectedBalance)
        {
            var presenter = new WithdrawPresenter();
            var sut = new Withdraw(
                _fixture.EntityFactory,
                presenter,
                _fixture.AccountRepository,
                _fixture.UnitOfWork
            );

            await sut.Execute(new WithdrawInput(
                _fixture.Context.DefaultAccountId,
                new PositiveMoney(amount)));

            var actual = presenter.Withdrawals.Last();
            Assert.Equal(expectedBalance, actual.UpdatedBalance);
        }
    }
}