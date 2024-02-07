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
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Order> AddAsync(Order order)
        {
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await GetByIdAsync(orderId);
            _dataContext.Orders.Remove(order);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dataContext.Orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int orderId)
        {
            return await _dataContext.Orders.FirstAsync(o => o.Id == orderId);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            var existOrder = await GetByIdAsync(order.Id);
            _dataContext.Entry(existOrder).CurrentValues.SetValues(order);
            await _dataContext.SaveChangesAsync();
            return existOrder;
        }
    }
}
