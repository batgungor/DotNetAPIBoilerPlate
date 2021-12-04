using DotNetCoreAPIBoilerPlate.Business.Engines.Models.Product;
using System.Collections.Generic;

namespace DotNetCoreAPIBoilerPlate.Business.Engines.Interfaces
{
    public interface ICatalogEngine : IEngineBase
    {
        List<ProductOverViewModel> GetProductListByCategoryIdForCatalog(int categoryId);
    }
}
