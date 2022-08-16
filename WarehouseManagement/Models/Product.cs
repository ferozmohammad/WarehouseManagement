using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Price { get; set; }
    }

    public class ProductsModel
    {
        public IList<Product> products { get; set; }
    }
}
