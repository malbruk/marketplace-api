using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();

        Task<Order> GetByIdAsync(int orderId);

        Task<Order> AddAsync(Order order);

        Task<Order> UpdateAsync(Order order);

        Task DeleteAsync(int orderId);
    }
}
