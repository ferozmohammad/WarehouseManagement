using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Inventory
    {
        public string Id { get; set; }
        public string WarehouseId { get; set; }
        public string ProductId { get; set; }
        public int Stock { get; set; }
    }

    public class InventoryModel
    {
        public IList<Inventory> inventories { get; set; }
    }
}
