using DotNet_Backend.Data.Contracts.Interfaces;
using System;
using System.Linq;

namespace DotNet_Backend.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IBlogContext _blogContext;

        public CommentRepository(IBlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public IQueryable<Comment> GetAll()
        {
            return _blogContext.Comments;
        }

        public IQueryable<Comment> GetAllFromUser(int userId)
        {
            return _blogContext.Comments.Where(c => c.UserId == userId);
        }

        public IQueryable<Comment> GetAllFromPost(int postId)
        {
            return _blogContext.Comments.Where(c => c.PostId == postId);
        }

        public Comment Get(int id)
        {
            return _blogContext.Comments.Find(id);
        }

        public Comment Add(Comment comment)
        {
            _blogContext.Comments.Add(comment);
            _blogContext.SaveChanges();

            return comment;
        }

        public Comment Update(Comment comment)
        {
            var c = Get(comment.Id);

            if (!string.IsNullOrEmpty(comment.Content))
            {
                c.Content = comment.Content;
            }

            c.LastEditDate = DateTime.UtcNow;

            _blogContext.Comments.Update(c);
            _blogContext.SaveChanges();

            return c;
        }

        public void Delete(int id)
        {
            var c = _blogContext.Comments.Find(id);
            _blogContext.Comments.Remove(c);
            _blogContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _blogContext.SaveChanges();
        }
    }
}