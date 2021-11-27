using System.Linq;
using DotNet_Backend.Model;

namespace DotNet_Backend.Data.Contracts.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetAllFromUser(int userId);
        IQueryable<Comment> GetAllFromPost(int postId);
    }
}