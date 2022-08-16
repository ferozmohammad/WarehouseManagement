using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataLayer.IDataLayer
{
    public interface IWarehouseData
    {
        Task<IList<Warehouse>> getWarehouse();
        Task<IList<Product>> getProducts();
        Task<IList<Inventory>> getInventories();
        Task<IList<ProdCategory>> getProdCategory();
        Task<bool> UpdateInventory(Inventory obj);
    }
}
