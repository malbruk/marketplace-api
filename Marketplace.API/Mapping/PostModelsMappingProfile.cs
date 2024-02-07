using AutoMapper;
using Marketplace.API.Models;
using Marketplace.Core.Entities;

namespace Marketplace.API.Mapping
{
    public class PostModelsMappingProfile : Profile
    {
        public PostModelsMappingProfile()
        {
            CreateMap<CategoryPostModel, Category>();
            CreateMap<CustomerPostModel, Customer>();
            CreateMap<ProductPostModel, Product>();
        }
    }
}
