using AutoMapper;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotNet_Backend.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostService(IMapper mapper, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postRepository = postRepository;
        }

        public List<PostDTO> GetAll()
        {
            var posts = _postRepository.GetAll();
            var postsDto = _mapper.Map<List<PostDTO>>(posts.ToList());

            return postsDto;
        }

        public List<PostDTO> GetAllFromUser(int userId)
        {
            var posts = _postRepository.GetAllFromUser(userId);
            var postsDto = _mapper.Map<List<PostDTO>>(posts.ToList());

            return postsDto;
        }

        public PostDTO GetPost(int id)
        {
            var post = _postRepository.Get(id);
            var postDto = _mapper.Map<PostDTO>(post);

            return postDto;
        }

        public PostDTO AddPost(PostRequest pr)
        {
            var p = new Post()
            {
                Title = pr.Title,
                Content = pr.Content,
                CreationDate = DateTime.UtcNow,
                LastEditDate = DateTime.UtcNow,
                UserId = pr.UserId
            };

            var post = _postRepository.Add(p);
            var postDto = _mapper.Map<PostDTO>(post);

            return postDto;
        }

        public PostDTO UpdatePost(PostRequest pr)
        {
            var p = new Post()
            {
                Id = pr.Id,
                Title = pr.Title,
                Content = pr.Content,
                LastEditDate = DateTime.UtcNow
            };

            var post = _postRepository.Update(p);
            var postDto = _mapper.Map<PostDTO>(post);

            return postDto;
        }

        public void DeletePost(int id)
        {
            _postRepository.Delete(id);
        }
    }
}