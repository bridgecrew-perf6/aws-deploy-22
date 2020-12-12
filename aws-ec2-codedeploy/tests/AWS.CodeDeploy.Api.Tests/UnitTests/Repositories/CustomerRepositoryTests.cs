using AWS.CodeDeploy.Api.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AWS.CodeDeploy.Api.Tests.UnitTests.Repositories
{
    public class CustomerRepositoryTests
    {
        [Fact(DisplayName = "CustomerRepository - Should get at least one customer")]
        public async Task CustomerRepository_Get()
        {
            //Arrange
            var customerRepository = new CustomerRepository();

            //Act
            var sut = await customerRepository.GetAll();

            //Assert
            Assert.True(sut.Count() > 0);
        }
    }
}
