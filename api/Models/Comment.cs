﻿namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

        public string Title { get; set; } =string.Empty;
        public Stock? Stock { get; set; }
        
        public int? StockId { get; set; }

    }
}
