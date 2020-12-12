using AWS.CodeDeploy.Api.Models;
using System;
using Xunit;

namespace AWS.CodeDeploy.Api.Tests.UnitTests.Models
{
    public class CustomerTests
    {

        [Fact(DisplayName = "Customer - Should add a valid customer")]
        public void Customer_AddValidCustomer()
        {
            //Arrage
            var id = Guid.NewGuid();
            var name = Faker.Name.FullName();
            var age = Faker.RandomNumber.Next();

            //Act
            var customer = new Customer
            {
                Id = id,
                Name = name,
                Age = age
            };

            //Assert
            Assert.Equal(id, customer.Id);
            Assert.Equal(name, customer.Name);
            Assert.Equal(age, customer.Age);
        }
    }
}
