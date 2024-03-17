using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]

    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;

        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo ,IStockRepository stockRepo  )
        {
           _commentRepo = commentRepo; 
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.ToList();

            return Ok(commentDto.ToList());
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comments = await _commentRepo.GetByIdAsync(id);
            if(comments.Count == 0)
            {
                return NotFound();
            }

            return Ok(comments.Select(s => s?.ToCommentDto()));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> CreateComment([FromRoute] int id , CreateCommentDto comment)
        {
            //validation
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (!await _stockRepo.StockExists(id)  )
            {
                return NotFound();
            }

            var comments = comment.ToComment(id);
            await _commentRepo.CreateAsync(comments);

            return Ok(comments);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var comment =  await _commentRepo.DeleteAsync(id);
            return Ok(comment);
        }



    }
}
