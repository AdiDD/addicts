using server.Data;
using server.Models;
using server.Services.Dependencies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Comment>> GetAllComments()
        {
            return await _commentService.GetAllAsync();
        }

        [HttpGet("{postId}")]
        public async Task<Comment> GetComment(int commentId)
        {
            return await _commentService.GetAsync(commentId);
        }

        [HttpPost]
        public async Task<Comment> AddComment(Comment comment)
        {
            return await _commentService.AddAsync(comment);
        }

        [HttpPut]
        public async Task<Comment> UpdateComment(Comment comment)
        {
            return await _commentService.UpdateAsync(comment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await _commentService.RemoveAsync(id);

            if (_commentService.GetAsync(id) == null)
                return Ok();

            return BadRequest();
        }
    }
}
