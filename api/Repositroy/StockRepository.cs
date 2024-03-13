using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }


        public  async Task<Stock?> GetDataByIdAsync(int id)
        {
            var DataById = await _context.Stocks.FindAsync(id);
            return DataById;
        }


        public async Task<Stock> CreateAsync( Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;

        }

        public async Task<Stock?> UpdateAsync(int id, CreateStockRequestDto stock)
        {
            var data = await _context.Stocks.FindAsync(id);
            if(data == null)
            {
                return null;
            }
            data.Purchase = stock.Purchase;
            data.Symbol = stock.Symbol;
            data.Industry = stock.Industry;
            data.MarkCap = stock.MarkCap;
            data.LastDiv = stock.LastDiv;
            data.Symbol = stock.Symbol;
            await _context.SaveChangesAsync();
            return data;
            
        }  
        public async Task<Stock?>  DeleteAsync(int id)
        {
            var isData = await _context.Stocks.FindAsync(id);
            if (isData == null)
            {
                return null ;
            }
            _context.Stocks.Remove(isData);
            await _context.SaveChangesAsync() ;
            return isData;
        }
    }
}
