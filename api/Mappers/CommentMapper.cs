using api.Dtos.Comment;
using api.Models;


namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {

            return new CommentDto
            {
                Id = commentModel.Id,
                CreatedOn = commentModel.CreatedOn,
                Content = commentModel.Content,
                Title = commentModel.Title
            };
        }

        public static Comment ToComment(this CreateCommentDto commentModel , int StockId)
        {

            return new Comment
            {
                Content = commentModel.Content,
                Title = commentModel.Title,
                StockId = StockId
            };
        }
    }
}
