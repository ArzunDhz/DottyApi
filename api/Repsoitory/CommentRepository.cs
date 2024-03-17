using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
          return await _context.Comments.ToListAsync(); 

        }

        public async Task<List<Comment?>> GetByIdAsync(int id)
        {
            var comments = await _context.Comments.Where(x => x.Id == id).ToListAsync();
            return comments!;
        }

        public async Task<Comment?> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var isComment =  await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if ( isComment == null)
            {
                return null;
            }
             _context.Comments.Remove(isComment);
             await _context.SaveChangesAsync();
            return isComment;
        }
    }
}
