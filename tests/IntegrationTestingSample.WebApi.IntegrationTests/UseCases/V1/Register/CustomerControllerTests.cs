using System;
using System.Threading.Tasks;
using FluentAssertions;
using IntegrationTestingSample.WebApi.Models.V1.Register;
using Xunit;

namespace IntegrationTestingSample.WebApi.IntegrationTests.UseCases.V1.Register
{
    public class CustomerControllerTests : TestBase
    {
        public CustomerControllerTests(ApiWebApplicationFactory fixture) 
            : base(fixture) {}

        [Fact]
        public async Task CanRegisterCustomer()
        {
            // Arrange
            var random = new Random();
            var request = new RegisterRequest
            {
                InitialAmount = 100,
                Name = "Test",
                SSN = "860817" + random.Next(1000, 9999)
            };

            // Act
            var response = await Client.RegisterCustomer(request);

            // Assert
            response.Should().NotBeNull();
            response.IsSuccessStatusCode.Should().BeTrue();
            response.Content.Should().NotBeNull();
            response.Content!.Name.Should().Be(request.Name);
            response.Content!.SSN.Should().Be(request.SSN);
            response.Content!.Accounts.Should().ContainSingle();
        }
    }
}
