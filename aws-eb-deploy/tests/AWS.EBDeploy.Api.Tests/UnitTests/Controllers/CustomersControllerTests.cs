using AWS.EBDeploy.Api.Controllers;
using AWS.EBDeploy.Api.Models;
using AWS.EBDeploy.Api.Repositories.Interfaces;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AWS.EBDeploy.Api.Tests.UnitTests.Controllers
{
    public class CustomersControllerTests
    {

        [Fact(DisplayName = "Customer Controller = Should get at least one customer and status code = 200")]
        public async Task CustomerController_GetCustomers_Moq()
        {
            //Arrange
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            moqCustomerRepository.Setup(x => x.GetAll())
                    .Returns(Task.FromResult(customers));

            //Act
            var customerController = new CustomersController(moqCustomerRepository.Object);
            var sut = await customerController.GetAll();

            //Assert
            Assert.True(sut.Count() > 0);
        }

        [Fact(DisplayName = "Customer Controller = Should get at least one customer and status code = 200")]
        public async Task CustomerController_GetCustomers_NSubstitute()
        {
            //Arrange
            var moqCustomerRepository = Substitute.For<ICustomerRepository>();
            moqCustomerRepository.GetAll().Returns(customers);

            //Act
            var customerController = new CustomersController(moqCustomerRepository);
            var sut = await customerController.GetAll();

            //Assert
            Assert.True(sut.Count() > 0);
        }

        private readonly IEnumerable<Customer> customers = new List<Customer> {
            new Customer{ Id = Guid.NewGuid(), Name = Faker.Name.FullName(), Age = Faker.RandomNumber.Next() },
            new Customer{ Id = Guid.NewGuid(), Name = Faker.Name.FullName(), Age = Faker.RandomNumber.Next() }
        };
    }
}
