using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Services.Interfaces;

namespace DotNet_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet()]
        public IActionResult GetAllComments()
        {
            var comments = _commentService.GetAll();
            return Ok(comments);
        }

        [HttpGet("User")]
        public IActionResult GetCommentsFromUser([FromQuery] int userId)
        {
            var comments = _commentService.GetAllFromUser(userId);
            return Ok(comments);
        }

        [HttpGet("Post")]
        public IActionResult GetCommentsFromPost([FromQuery] int postId)
        {
            var comments = _commentService.GetAllFromPost(postId);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            return Ok(comment);
        }

        [HttpPost()]
        public IActionResult AddComment(CommentRequest cr)
        {
            var comment = _commentService.AddComment(cr);
            return Ok(comment);
        }

        [HttpPut()]
        public IActionResult UpdateComment(CommentRequest cr)
        {
            var comment = _commentService.UpdateComment(cr);
            return Ok(comment);
        }

        [HttpDelete()]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return Ok();
        }
    }
}
