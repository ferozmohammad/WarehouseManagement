using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.Models;

namespace WarehouseManagement.Repositories.IRepositories
{
    public interface IWarehouseRepo
    {
        Task<IList<Warehouse>> getWarehouse();
        Task<IList<Product>> getProduct();
        Task<IList<Inventory>> getInventory();
        Task<IList<ProdCategory>> getProdCategory();
        Task<bool> UpdateInventory(Inventory obj);
    }
}
