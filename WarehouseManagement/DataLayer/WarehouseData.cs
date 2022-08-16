using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseManagement.DataLayer.IDataLayer;
using WarehouseManagement.Models;

namespace WarehouseManagement.DataLayer
{
    public class WarehouseData : IWarehouseData
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private string _jsonData { get; set; }
        private string _jsonPath { get; set; }
        public WarehouseData(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            _jsonPath = Path.Combine(_appEnvironment.WebRootPath, "warehousedata.json");
            _jsonData = File.ReadAllText(_jsonPath);
        }
        public async Task<IList<Inventory>> getInventories()
        {
            var result = JsonConvert.DeserializeObject<InventoryModel>(_jsonData);
           return await Task.FromResult(result.inventories);
        }

        public async Task<IList<Product>> getProducts()
        {
            var result = JsonConvert.DeserializeObject<ProductsModel>(_jsonData);
            return await Task.FromResult(result.products);
        }

        public async Task<IList<Warehouse>> getWarehouse()
        {
            var result = JsonConvert.DeserializeObject<WarehouseModel>(_jsonData);
            return await Task.FromResult(result.warehouses);
        }

        public async Task<bool> UpdateInventory(Inventory obj)
        {
            var tagName = "inventories";
            
            try
            {
                string json = File.ReadAllText(_jsonPath);

                JObject jObject = JObject.Parse(json);
                JArray configArrary = (JArray)jObject[tagName];

                if (!string.IsNullOrWhiteSpace(obj.WarehouseId) && !string.IsNullOrWhiteSpace(obj.ProductId))
                {
                    var Items = configArrary.Where(o => o["warehouseId"].Value<string>().Equals(obj.WarehouseId) &&
                                                        o["productId"].Value<string>().Equals(obj.ProductId));
                    if(Items.Count() > 0)
                    {
                        // UPDATE
                        foreach (JToken item in Items)
                        {
                            item["stock"] = obj.Stock;
                        }
                    }
                    else
                    {
                        //ADD 

                        configArrary.Add(configArrary.FirstOrDefault());
                        JToken item = configArrary.LastOrDefault();
                        if (item != null)
                        {
                            item["stock"] = obj.Stock;
                            item["warehouseId"] = obj.WarehouseId;
                            item["productId"] = obj.ProductId;
                            item["id"] = $"IND{configArrary.Count() + 1}";
                        }
                    }
                   

                    jObject[tagName] = configArrary;
                    string output = JsonConvert.SerializeObject(jObject, Formatting.Indented);
                    File.WriteAllText(_jsonPath, output);
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception e)
            {

                
            }


            return await Task.FromResult(true);
        }

        public async Task<IList<ProdCategory>> getProdCategory()
        {
            var result = JsonConvert.DeserializeObject<ProdCategoryModel>(_jsonData);
            return await Task.FromResult(result.prodCategories);
        }
    }
}
