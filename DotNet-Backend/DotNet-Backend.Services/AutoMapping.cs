using AutoMapper;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;

namespace DotNet_Backend.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}