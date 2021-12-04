using AutoMapper;
using DotNetCoreAPIBoilerPlate.Business.Engines.Models.Product;
using DotNetCoreAPIBoilerPlate.Data.Entities;

namespace DotNetCoreAPIBoilerPlate.Business.Engines.Infrastructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductEntity, ProductOverViewModel>();
            CreateMap<CategoryEntity, ProductOverViewModel.ProductCategoryModel>();
        }
    }
}