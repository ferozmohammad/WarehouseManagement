using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.DataLayer.IDataLayer;
using WarehouseManagement.Models;
using WarehouseManagement.Providers.IProviders;

namespace WarehouseManagement.Providers
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseData _iWarehouseData;
        public WarehouseService(IWarehouseData iWarehouseData)
        {
            _iWarehouseData = iWarehouseData;
        }
        public async Task<IList<Inventory>> getInventories()
        {
            var result = await _iWarehouseData.getInventories();
            return result;
        }

        public async Task<IList<ProdCategory>> getProdCategory()
        {
            var result = await _iWarehouseData.getProdCategory();
            return result;
        }

        public async Task<IList<Product>> getProducts()
        {
            var result = await _iWarehouseData.getProducts();
            return result;
        }

        public async Task<IList<Warehouse>> getWarehouse()
        {
            var result = await _iWarehouseData.getWarehouse();
            return result;
        }

        public async Task<bool> UpdateInventory(Inventory obj)
        {
            var result = await _iWarehouseData.UpdateInventory(obj);
            return result;
        }
    }
}
