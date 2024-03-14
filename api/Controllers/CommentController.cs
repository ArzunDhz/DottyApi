﻿using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]

   
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo )
        {
           _commentRepo = commentRepo; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto()).ToList();

            return Ok(commentDto.ToList());
        }



    }
}
