using AutoMapper;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Requests;

namespace DotNet_Backend.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Comment, CommentDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<User, UserDTO>();

            CreateMap<CommentRequest, Comment>();
            CreateMap<PostRequest, Post>();
            CreateMap<UserRequest, User>();
        }
    }
}