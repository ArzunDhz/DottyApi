using api.Dtos.Comment;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();

        Task<List<Comment?>> GetByIdAsync(int id);

        Task<Comment?> CreateAsync(Comment comment);

        Task<Comment?> DeleteAsync(int id );

    }
}
