using server.Data;
using server.Models;
using server.Services.Dependencies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postService.GetAllAsync();
        }

        [HttpGet("{postId}")]
        public async Task<Post> GetPost(int postId)
        {
            return await _postService.GetAsync(postId);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<Post> AddPost(Post post)
        {
            return await _postService.AddAsync(post);
        }

        [HttpPut]
        public async Task<Post> UpdatePost(Post post)
        {
            return await _postService.UpdateAsync(post);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            await _postService.RemoveAsync(id);

            if (_postService.GetAsync(id) == null)
                return Ok();

            return BadRequest();
        }
    }
}
