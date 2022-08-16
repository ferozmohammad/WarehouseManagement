using System.Collections.Generic;

namespace WarehouseManagement.Models
{
    public class Warehouse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ManagerId { get; set; }

    }

    public class WarehouseModel
    {
        public IList<Warehouse> warehouses { get; set; }
    }
}
