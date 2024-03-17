namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string Title { get; set; } =string.Empty;
        public Stock? Stock { get; set; }
        
        public int? StockId { get; set; }

    }
}
