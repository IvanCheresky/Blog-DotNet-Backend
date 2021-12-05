using System;
using System.Collections.Generic;

namespace DotNet_Backend.Data.Contracts.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<PostDTO> Posts { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLogin { get; set; }

    }
}