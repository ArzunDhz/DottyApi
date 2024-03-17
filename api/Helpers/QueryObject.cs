using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace api.Helpers
{


    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? Name { get; set; }
        public string? Industry { get; set; } = string.Empty;
        public string SortBy { get; set; } =  string.Empty ;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 20;

    }
}
