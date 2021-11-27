using System.Collections.Generic;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Data.Repositories;

namespace DotNet_Backend.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetUser(int id);
        UserDTO RegisterUser(UserRequest u);
        UserDTO UpdateUser(UserRequest u);
        void DeleteUser(int id);
    }
}