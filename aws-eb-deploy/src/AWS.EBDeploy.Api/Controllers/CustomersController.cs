using AWS.EBDeploy.Api.Models;
using AWS.EBDeploy.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWS.EBDeploy.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Customer> Get(Guid id)
        {
            return await _customerRepository.Get(id);
        }
    }
}
