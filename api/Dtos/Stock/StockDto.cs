﻿using api.Dtos.Comment;
using api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarkCap { get; set; }
        public string? Symbol { get; internal set; }
        public List<CommentDto> Comments { get; set; }
    }
}
