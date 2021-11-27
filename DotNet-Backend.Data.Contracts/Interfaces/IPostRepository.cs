using System.Linq;
using DotNet_Backend.Model;

namespace DotNet_Backend.Data.Contracts.Interfaces
{
    public interface IPostRepository : IRepository<Post>
    {
        IQueryable<Post> GetAllFromUser(int userId);
    }
}