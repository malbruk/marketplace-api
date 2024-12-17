using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data.Repositories
{
    public class RepositoryManager(DataContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, ICustomerRepository customerRepository) : IRepositoryManager
    {
        private readonly DataContext _context = context;

        public IProductRepository Products => productRepository;

        public ICategoryRepository Categories => categoryRepository;

        public IOrderRepository Orders => orderRepository;

        public ICustomerRepository Customers => customerRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
