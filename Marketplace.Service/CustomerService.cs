using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Marketplace.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        public async Task DeleteAsync(int customerId)
        {
            await _customerRepository.DeleteAsync(customerId);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _customerRepository.GetByIdAsync(customerId);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            return await _customerRepository.UpdateAsync(customer);
        }
    }
}
