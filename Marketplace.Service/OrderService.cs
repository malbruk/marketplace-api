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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> AddAsync(Order order)
        {
            return await _orderRepository.AddAsync(order);
        }

        public async Task DeleteAsync(int orderId)
        {
            await _orderRepository.DeleteAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public Task<Order> GetByIdAsync(int orderId)
        {
            return _orderRepository.GetByIdAsync(orderId);
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            return await _orderRepository.UpdateAsync(order);
        }
    }
}
