namespace Marketplace.API.Models
{
    public class ProductPostModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public List<int> CategoriesIds { get; set; }
    }
}
