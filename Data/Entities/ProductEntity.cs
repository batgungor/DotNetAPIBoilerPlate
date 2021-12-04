using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCoreAPIBoilerPlate.Data.Entities
{
    [Table("Products")]
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
