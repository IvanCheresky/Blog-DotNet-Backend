using System;
using System.Collections.Generic;

namespace DotNet_Backend.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastLogin { get; set; }
    }
}