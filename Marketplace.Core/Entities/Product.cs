using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }
    }
}
