using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int categoryId);

        Task<Category> AddAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task DeleteAsync(int categoryId);
    }
}
