using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMapper
    {
        public static StockDto ToStockDto( this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                Industry = stockModel.Industry, 
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarkCap = stockModel.MarkCap,
                Name = stockModel.Name,
                Comments = stockModel.Comments.Select( x => x.ToCommentDto()).ToList(),
            };
        }

        public static Stock ToCreateStockRequestDto( this CreateStockRequestDto stockModel )
        {
            return new Stock
            {
                Industry = stockModel.Industry,
                Symbol = stockModel.Symbol,
                Purchase = stockModel .Purchase,
                LastDiv = stockModel .LastDiv,
                MarkCap = stockModel .MarkCap,
                Name = stockModel.Name,             
            };
        }

     
    }
}
