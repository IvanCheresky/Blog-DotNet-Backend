using System;
using System.Collections.Generic;

namespace DotNet_Backend.Data.Contracts.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public UserDTO User { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastEditDate { get; set; }
    }
}