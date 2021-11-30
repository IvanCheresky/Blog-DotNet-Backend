using System;

namespace DotNet_Backend.Data.Contracts.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public UserDTO User { get; set; }
        public int PostId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}