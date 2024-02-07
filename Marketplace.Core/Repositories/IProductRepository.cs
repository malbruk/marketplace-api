using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int productId);

        Task<Product> AddAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task DeleteAsync(int productId);
    }
}
