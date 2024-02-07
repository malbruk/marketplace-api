using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _dataContext;

        public CustomerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            _dataContext.Customers.Add(customer);
            await _dataContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await GetByIdAsync(customerId);
            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _dataContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int customerId)
        {
            return await _dataContext.Customers.FirstAsync(c => c.Id == customerId);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var existCustomer = await GetByIdAsync(customer.Id);
            _dataContext.Entry(existCustomer).CurrentValues.SetValues(customer);
            await _dataContext.SaveChangesAsync();
            return existCustomer;
        }
    }
}
