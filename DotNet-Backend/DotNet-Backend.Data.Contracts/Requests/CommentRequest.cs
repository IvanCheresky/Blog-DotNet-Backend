using System;

namespace DotNet_Backend.Data.Contracts.Requests
{
    public class CommentRequest
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}