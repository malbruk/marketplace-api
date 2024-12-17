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
    public class CustomerService(IRepositoryManager respositoryManager) : ICustomerService
    {
        private readonly IRepositoryManager _respositoryManager = respositoryManager;


        public async Task<Customer> AddAsync(Customer customer)
        {
            _respositoryManager.Customers.Add(customer);
            await _respositoryManager.SaveAsync();
            return customer;
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await GetByIdAsync(customerId);
            _respositoryManager.Customers.Delete(customer);
            await _respositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _respositoryManager.Customers.GetListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int customerId)
        {
            return await _respositoryManager.Customers.GetByIdAsync(customerId);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _respositoryManager.Customers.Update(customer);
            await _respositoryManager.SaveAsync();
            return customer;
        }
    }
}
