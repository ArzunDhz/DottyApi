namespace api.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Context { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

        public Stock? Stock { get; set; }

        public int? StockId { get; set; }

    }
}
