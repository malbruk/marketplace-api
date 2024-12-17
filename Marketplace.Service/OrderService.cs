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
    public class OrderService(IRepositoryManager repositoryManager) : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;

        public async Task<Order> AddAsync(Order order)
        {
            _repositoryManager.Orders.Add(order);
            await _repositoryManager.SaveAsync();
            return order;
        }

        public async Task DeleteAsync(int orderId)
        {
            var order = await GetByIdAsync(orderId);
            _repositoryManager.Orders.Delete(order);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _repositoryManager.Orders.GetListAsync();
        }

        public Task<Order?> GetByIdAsync(int orderId)
        {
            return _repositoryManager.Orders.GetByIdAsync(orderId);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            _repositoryManager.Orders.Update(order);
            await _repositoryManager.SaveAsync();
            return order;
        }
    }
}
