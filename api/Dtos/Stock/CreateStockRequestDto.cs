using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        public string? Symbol { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarkCap { get; set; }

    }
}
