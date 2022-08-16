using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseManagement.Models;
using WarehouseManagement.Providers.IProviders;
using WarehouseManagement.Repositories.IRepositories;

namespace WarehouseManagement.Repositories
{
    public class WarehouseRepo : IWarehouseRepo
    {
        private readonly IWarehouseService _iWarehouseService;

        public WarehouseRepo(IWarehouseService iWarehouseService)
        {
            _iWarehouseService = iWarehouseService;
        }
        public async Task<IList<Inventory>> getInventory()
        {
            var result = await _iWarehouseService.getInventories();
            return result;
        }

        public async Task<IList<ProdCategory>> getProdCategory()
        {
            var result = await _iWarehouseService.getProdCategory();
            return result;
        }

        public  async Task<IList<Product>> getProduct()
        {
            var result = await _iWarehouseService.getProducts();
            return result;
        }

        public async Task<IList<Warehouse>> getWarehouse()
        {
            var result = await _iWarehouseService.getWarehouse();
            return result;
        }

        public async Task<bool> UpdateInventory(Inventory obj)
        {
            var result = await _iWarehouseService.UpdateInventory(obj);
            return result;
        }
    }
}
