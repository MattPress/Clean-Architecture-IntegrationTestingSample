using IntegrationTestingSample.Application.Repositories;
using IntegrationTestingSample.WebApi.Client;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using Xunit;

namespace IntegrationTestingSample.WebApi.IntegrationTests
{
    public abstract class TestBase : IClassFixture<ApiWebApplicationFactory>
    {
        protected ApiWebApplicationFactory Factory { get; }

        protected IClient Client { get; }

        protected Mock<IAccountRepository> MockAccountRepository { get; } =
            new Mock<IAccountRepository> { CallBase = true };

        protected Mock<ICustomerRepository> MockCustomerRepository { get; } = 
            new Mock<ICustomerRepository> { CallBase = true };

        protected TestBase(ApiWebApplicationFactory factory)
        {
            Factory = factory;
            CreateMockContainer();
            Client = CreateClient();
        }

        protected IClient CreateClient()
        {
            return RestService.For<IClient>(Factory.CreateClient(), new RefitSettings
            {
                HttpMessageHandlerFactory = () => Factory.Server.CreateHandler(),
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }),
                Buffered = true
            });
        }

        private void CreateMockContainer()
        {
            Factory.ContainerOverride = services =>
            {
                services.AddScoped(x => MockAccountRepository.Object);
                services.AddScoped(x => MockCustomerRepository.Object);
            };
        }
    }
}
