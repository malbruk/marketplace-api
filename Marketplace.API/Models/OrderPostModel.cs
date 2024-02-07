using Marketplace.Core.DTOs;
using Marketplace.Core.Entities;

namespace Marketplace.API.Models
{
    public class OrderPostModel
    {
        public int CustomerId { get; set; }

        public Dictionary<int, int> Products { get; set; }
    }
}
