using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject q);

        Task<Stock> CreateAsync( Stock stock);

        Task<Stock?> GetDataByIdAsync(int id);

        Task<Stock?> UpdateAsync(int id , CreateStockRequestDto stock);

        Task <Stock?> DeleteAsync(int id);

        Task<bool> StockExists( int id);

    }
}
