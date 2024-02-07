using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();

        Task<Customer> GetByIdAsync(int customerId);

        Task<Customer> AddAsync(Customer customer);

        Task<Customer> UpdateAsync(Customer customer);

        Task DeleteAsync(int customerId);
    }
}
