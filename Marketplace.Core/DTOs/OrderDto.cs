using Marketplace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public CustomerDto Customer { get; set; }

        public IEnumerable<OrderProductDto> Products { get; set; }

        public bool Paid { get; set; }

        public EOrderStatus Status { get; set; }
    }
}
