using System;
using System.Collections;
using System.Collections.Generic;

namespace DotNet_Backend.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime CreationDate { get; set; }
    }
}