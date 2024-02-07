using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.DTOs
{
    public class OrderProductDto
    {
        public ProductDto Product { get; set; }

        public int Quantity { get; set; }
    }
}
