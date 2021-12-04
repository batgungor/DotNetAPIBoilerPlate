using DotNetCoreAPIBoilerPlate.Business.Engines.Interfaces;
using DotNetCoreAPIBoilerPlate.Business.Engines.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreAPIBoilerPlate.Application.API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICatalogEngine _catalogEngine;
        public CategoriesController(ICatalogEngine catalogEngine)
        {
            _catalogEngine = catalogEngine;
        }
        [HttpGet("{id}/Products")]
        public List<ProductOverViewModel> GetCategoryProducts(int id)
        {
            var data = _catalogEngine.GetProductListByCategoryIdForCatalog(id);
            return data;
        }
    }
}
