using AWS.CodeDeploy.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.CodeDeploy.Api.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Get(Guid id);
    }
}
