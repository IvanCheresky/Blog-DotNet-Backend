using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet()]
        public IActionResult GetAllPosts()
        {
            var posts = _postService.GetAll();
            return Ok(posts);
        }

        [HttpGet("User")]
        public IActionResult GetCommentsFromUser([FromQuery] int userId)
        {
            var posts = _postService.GetAllFromUser(userId);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int id)
        {
            var post = _postService.GetPost(id);
            return Ok(post);
        }

        [HttpPost()]
        public IActionResult AddComment(PostRequest pr)
        {
            var post = _postService.AddPost(pr);
            return Ok(post);
        }

        [HttpPut()]
        public IActionResult UpdateComment(PostRequest pr)
        {
            var post = _postService.UpdatePost(pr);
            return Ok(post);
        }

        [HttpDelete()]
        public IActionResult DeletePost(int id)
        {
            _postService.DeletePost(id);
            return Ok();
        }
    }
}
