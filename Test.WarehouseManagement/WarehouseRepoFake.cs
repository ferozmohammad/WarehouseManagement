using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Models;
using WarehouseManagement.Repositories.IRepositories;

namespace Test.WarehouseManagement
{
    public class WarehouseRepoFake : IWarehouseRepo
    {
        private List<Inventory> _inventoryList;
        public WarehouseRepoFake()
        {
            _inventoryList = new List<Inventory>();
            _inventoryList.Add(new Inventory() { Id = "IND1", ProductId = "P1", WarehouseId = "W1", Stock = 22 });
            _inventoryList.Add(new Inventory() { Id = "IND2", ProductId = "P2", WarehouseId = "W2", Stock = 20});
            _inventoryList.Add(new Inventory() { Id = "IND3", ProductId = "P3", WarehouseId = "W3", Stock = 5 });

        }
        public async Task<IList<Inventory>> getInventory()
        {
            return await Task.FromResult(_inventoryList);
        }

        public Task<IList<ProdCategory>> getProdCategory()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Product>> getProduct()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Warehouse>> getWarehouse()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateInventory(Inventory obj)
        {
            if(_inventoryList.Find(x => x.Id == obj.Id) == null) { return false; }

            _inventoryList = _inventoryList.Where(x => x.Id != obj.Id).ToList();
            _inventoryList.Add(obj);
            return await Task.FromResult(true);
        }
    }
}
