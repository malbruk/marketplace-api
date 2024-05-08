using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Order { get; set; }

        public int? ParentId { get; set; }

        public List<CategoryDto>? Children { get; set; }

    }
}
