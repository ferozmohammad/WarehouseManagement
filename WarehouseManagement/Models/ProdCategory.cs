using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class ProdCategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class ProdCategoryModel
    {
        public IList<ProdCategory> prodCategories { get; set; }
    }
}
