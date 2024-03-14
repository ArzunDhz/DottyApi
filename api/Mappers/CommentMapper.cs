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
                StockId = commentModel.StockId,
                CreatedOn = commentModel.CreatedOn,
                Content = commentModel.Content,
                Title = commentModel.Title
            };
        }

    }
}
