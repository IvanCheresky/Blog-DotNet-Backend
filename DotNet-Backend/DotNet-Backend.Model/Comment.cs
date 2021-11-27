using System;

namespace DotNet_Backend.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}