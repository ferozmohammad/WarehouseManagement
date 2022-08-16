using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WarehouseManagement.Models;
using WarehouseManagement.Repositories.IRepositories;

namespace WarehouseManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepo _iWarehouseRepo;
        public WarehouseController(IWarehouseRepo iWarehouseRepo)
        {
            _iWarehouseRepo = iWarehouseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _iWarehouseRepo.getProduct();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getWarehouses()
        {
            var result = await _iWarehouseRepo.getWarehouse();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getInventories()
        {
            var result = await _iWarehouseRepo.getInventory();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getProdCategories()
        {
            var result = await _iWarehouseRepo.getProdCategory();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateInventory([FromBody]Inventory obj)
        {
            var result = await _iWarehouseRepo.UpdateInventory(obj);
            return Ok(result);
        }

    }
}
