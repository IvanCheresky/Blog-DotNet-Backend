using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Model;

namespace DotNet_Backend.Data.Contracts.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
    }
}