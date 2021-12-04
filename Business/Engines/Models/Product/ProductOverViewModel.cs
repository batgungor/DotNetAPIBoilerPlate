using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreAPIBoilerPlate.Business.Engines.Models.Product
{
    public class ProductOverViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductCategoryModel Category { get; set; }

        #region Nested Classes
        public class ProductCategoryModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        #endregion
    }
}
