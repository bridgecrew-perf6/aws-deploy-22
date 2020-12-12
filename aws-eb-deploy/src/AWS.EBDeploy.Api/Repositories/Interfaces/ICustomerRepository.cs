using AWS.EBDeploy.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.EBDeploy.Api.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> Get(Guid id);
    }
}
