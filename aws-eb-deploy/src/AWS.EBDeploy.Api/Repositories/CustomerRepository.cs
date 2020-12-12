using AWS.EBDeploy.Api.Models;
using AWS.EBDeploy.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS.EBDeploy.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await Task.FromResult(customers.ToList());
        }

        public async Task<Customer> Get(Guid id)
        {
            return await Task.FromResult(customers.FirstOrDefault());
        }

        private readonly List<Customer> customers = new List<Customer> {
            new Customer{ Id = Guid.NewGuid(), Name = Faker.Name.FullName(), Age = Faker.RandomNumber.Next() },
            new Customer{ Id = Guid.NewGuid(), Name = Faker.Name.FullName(), Age = Faker.RandomNumber.Next() },
            new Customer{ Id = Guid.NewGuid(), Name = Faker.Name.FullName(), Age = Faker.RandomNumber.Next() },
            new Customer{ Id = Guid.NewGuid(), Name = Faker.Name.FullName(), Age = Faker.RandomNumber.Next() },
        };


    }
}
