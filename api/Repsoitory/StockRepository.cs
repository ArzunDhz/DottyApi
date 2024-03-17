using api.Data;
using api.Dtos.Stock;
using api.Helpers;
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

        public async Task<List<Stock>> GetAllAsync( QueryObject q)
        {
            //marking that stock will be quarable
            var stocks =  _context.Stocks.Include(c=>c.Comments).AsQueryable();


            // for getting name
            if(!string.IsNullOrWhiteSpace(q.Name))
            {
                stocks = stocks.Where(s => s.Name.Contains(q.Name));
            }
            //for getting symbol

            if (!string.IsNullOrWhiteSpace(q.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(q.Symbol));
            }

            //for getting Industry

            if (!string.IsNullOrWhiteSpace(q.Industry))
            {
                stocks = stocks.Where(s => s.Industry.Contains(q.Industry));
            }

            //formatting the order asc or decs of the SortBy type
            if (!string.IsNullOrEmpty(q.SortBy))
            {
                if (q.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                 stocks = q.IsDescending ? stocks.OrderByDescending( s => s.Symbol) : stocks.OrderBy(s => s.Symbol) ;   
                }

                if (q.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = q.IsDescending ? stocks.OrderByDescending(s => s.Name) : stocks.OrderBy(s => s.Name);
                }

                if (q.SortBy.Equals("Industry", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = q.IsDescending ? stocks.OrderByDescending(s => s.Industry) : stocks.OrderBy(s => s.Industry);
                }

                if (q.SortBy.Equals("Purchase", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = q.IsDescending ? stocks.OrderByDescending(s => s.Purchase) : stocks.OrderBy(s => s.Purchase);
                }

            }
            // for pagination
                var skipNumber = ( q.PageNumber -1)* q.PageSize;
                return  await stocks.Skip(skipNumber).Take(q.PageSize).ToListAsync();
        }


        public  async Task<Stock?> GetDataByIdAsync(int id)
        {
            var DataById = await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<bool> StockExists(int id)
        {
          return await _context.Stocks.AnyAsync(x => x.Id == id); 
        }

   
    }
}
