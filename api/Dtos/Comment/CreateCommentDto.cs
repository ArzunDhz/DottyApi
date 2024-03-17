using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Min length must be 5")]
        [MaxLength(10, ErrorMessage = "Max length must be less then 10")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Min length must be 5")]
        [MaxLength(10, ErrorMessage = "Max length must be less then 10")]
        public string Content { get; set; } = string.Empty;
    }
}
