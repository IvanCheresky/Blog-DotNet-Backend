using System.Collections.Generic;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Requests;

namespace DotNet_Backend.Services.Interfaces
{
    public interface IPostService
    {
        List<PostDTO> GetAll();
        List<PostDTO> GetAllFromUser(int userId);
        PostDTO GetPost(int id);
        PostDTO AddPost(PostRequest pr);
        PostDTO UpdatePost(PostRequest pr);
        void DeletePost(int id);
    }
}