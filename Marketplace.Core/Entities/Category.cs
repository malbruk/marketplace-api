using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Icon { get; set; }

        public int Order { get; set; }

        public int? ParentId { get; set; }

        //public Category? Parent { get; set; }

        [ForeignKey("ParentId")]
        public List<Category>? Children { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
