using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<OrderProduct> Products { get; set; }

        public bool Paid { get; set; }

        public EOrderStatus Status { get; set; }
    }
}
