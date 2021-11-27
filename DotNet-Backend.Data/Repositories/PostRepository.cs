using DotNet_Backend.Data.Contracts.Interfaces;
using System;
using System.Linq;

namespace DotNet_Backend.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IBlogContext _blogContext;

        public PostRepository(IBlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IQueryable<Post> GetAll()
        {
            return _blogContext.Posts;
        }

        public IQueryable<Post> GetAllFromUser(int userId)
        {
            return _blogContext.Posts.Where(p => p.UserId == userId);
        }

        public Post Get(int id)
        {
            return _blogContext.Posts.Find(id);
        }

        public Post Add(Post post)
        {
            _blogContext.Posts.Add(post);
            _blogContext.SaveChanges();

            return post;
        }

        public Post Update(Post post)
        {
            var p = Get(post.Id);

            if (!string.IsNullOrEmpty(post.Title))
            {
                p.Title = post.Title;
            }

            if (!string.IsNullOrEmpty(post.Content))
            {
                p.Content = post.Content;
            }

            p.LastEditDate = DateTime.UtcNow;

            _blogContext.Posts.Update(p);
            _blogContext.SaveChanges();

            return p;
        }

        public void Delete(int id)
        {
            var p = _blogContext.Posts.Find(id);
            _blogContext.Posts.Remove(p);
            _blogContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _blogContext.SaveChanges();
        }
    }
}