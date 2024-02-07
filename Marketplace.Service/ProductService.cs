using Marketplace.Core.Entities;
using Marketplace.Core.Repositories;
using Marketplace.Core.Services;
using Marketplace.Service.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddAsync(Product product)
        {
            product.Slug = product.Name.Slugify();
            return await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public Task<Product> GetByIdAsync(int productId)
        {
            return _productRepository.GetByIdAsync(productId);
        }

        public Task<Product> UpdateAsync(Product product)
        {
            product.Slug = product.Name.Slugify();
            return _productRepository.UpdateAsync(product);
        }
    }
}
