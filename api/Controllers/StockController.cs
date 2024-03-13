
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;  // Make sure to include this for Entity Framework Core

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepo;
        public StockController( IStockRepository stockRepo )
        {
            _stockRepo = stockRepo; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            // Use async/await properly with ToListAsync()
            var stocks = await _stockRepo.GetAllAsync();
            var stockDtos = stocks.Select(s => s.ToStockDto());
            return Ok(stockDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock =  await _stockRepo.GetDataByIdAsync(id);
          
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> PostStock([FromBody] CreateStockRequestDto stockDto)
        {
            var stock =  stockDto.ToCreateStockRequestDto();
            var data = await _stockRepo.CreateAsync(stock);
            return  CreatedAtAction(nameof(GetById), new { id = stock.Id }, stock.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task<IActionResult> UpdateStock([FromRoute] int id, [FromBody] CreateStockRequestDto cs  )
        {
            var isStock = await _stockRepo.UpdateAsync(id, cs);
            if (isStock == null)
            {
                return NotFound();
            }
            return Ok(isStock.ToStockDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute]int id)
        {
            var isStock = await _stockRepo.DeleteAsync(id);
            if(isStock == null)
            {
                return NotFound();
            }
            return Ok(true);

        }
        

  




    }
}
