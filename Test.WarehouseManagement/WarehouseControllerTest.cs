using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagement.Controllers;
using WarehouseManagement.Models;
using WarehouseManagement.Repositories.IRepositories;
using Xunit;

namespace Test.WarehouseManagement
{
    public class WarehouseControllerTest
    {
        private readonly WarehouseController _controller;
        private readonly IWarehouseRepo _iWarehouseRepo;

        public WarehouseControllerTest()
        {
            _iWarehouseRepo = new WarehouseRepoFake();
            _controller = new WarehouseController(_iWarehouseRepo);
        }



        [Fact]
        public async Task Get_AllInventoryItems()
        {
            // Act
            var result = await _controller.getInventories();
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        
            var items = Assert.IsType<List<Inventory>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public async Task Update_InventoryItems()
        {
            var updatedStock = 5;
            var _inventoryObj = new Inventory() { Id = "IND2", ProductId = "P2", WarehouseId = "W2", Stock = updatedStock };
            
            // Act
            var result = await _controller.UpdateInventory(_inventoryObj);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult);

            Assert.Equal(true, okResult.Value);

            var result1 = await _controller.getInventories();
            var okResult1 = Assert.IsType<OkObjectResult>(result1);
            var items = Assert.IsType<List<Inventory>>(okResult1.Value);
            Assert.Equal(updatedStock, items.FirstOrDefault(x=>x.Id== "IND2").Stock);
        }
    }
}
