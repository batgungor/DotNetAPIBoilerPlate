using AutoMapper;
using DotNetCoreAPIBoilerPlate.Business.Engines.Interfaces;
using DotNetCoreAPIBoilerPlate.Business.Engines.Models.Product;
using DotNetCoreAPIBoilerPlate.Data.DAL.UnitOfWork;
using DotNetCoreAPIBoilerPlate.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DotNetCoreAPIBoilerPlate.Business.Engines.Implementations
{
    public class CatalogEngine : ICatalogEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CatalogEngine(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public List<ProductOverViewModel> GetProductListByCategoryIdForCatalog(int categoryId)
        {
            var productRepository = _unitOfWork.GetRepository<ProductEntity>();
            var products = productRepository.Get(q => q.CategoryId == categoryId)
                .Select(product => _mapper.Map<ProductOverViewModel>(product)).ToList();
            return products;
        }
    }
}
