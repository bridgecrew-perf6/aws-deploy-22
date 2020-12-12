using AWS.EBDeploy.Api.Models;
using AWS.EBDeploy.Api.Tests.IntegrationTests.Config;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AWS.EBDeploy.Api.Tests.IntegrationTests
{
    [Collection(nameof(IntegrationTestsFixtureCollection))]
    public class CustomersControllerTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public CustomersControllerTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Customers = Should get customers and return status code 200")]
        public async Task Customers_GetAll_Returns200Success()
        {
            // Arrange
            // Act
            var response = await _testsFixture.Client.GetAsync("/customers");
            var result = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(result);

            // Assert
            Assert.True(response.EnsureSuccessStatusCode().IsSuccessStatusCode);
            Assert.True(customers.Count() > 0);
        }
    }
}
