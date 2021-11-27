using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DotNet_Backend.Data;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Interfaces;
using DotNet_Backend.Data.Contracts.Requests;
using DotNet_Backend.Services.Interfaces;

namespace DotNet_Backend.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public List<CommentDTO> GetAll()
        {
            var comments = _commentRepository.GetAll();
            var commentsDto = _mapper.Map<List<CommentDTO>>(comments.ToList());

            return commentsDto;
        }

        public List<CommentDTO> GetAllFromUser(int userId)
        {
            var comments = _commentRepository.GetAllFromUser(userId);
            var commentsDto = _mapper.Map<List<CommentDTO>>(comments.ToList());

            return commentsDto;
        }

        public List<CommentDTO> GetAllFromPost(int postId)
        {
            var comments = _commentRepository.GetAllFromPost(postId);
            var commentsDto = _mapper.Map<List<CommentDTO>>(comments.ToList());

            return commentsDto;
        }

        public CommentDTO GetComment(int id)
        {
            var comment = _commentRepository.Get(id);
            var commentDto = _mapper.Map<CommentDTO>(comment);

            return commentDto;
        }

        public CommentDTO AddComment(CommentRequest cr)
        {
            var c = new Comment()
            {
                Content = cr.Content,
                CreationDate = DateTime.UtcNow,
                LastEditDate = DateTime.UtcNow,
                PostId = cr.PostId,
                UserId = cr.UserId
            };

            var comment = _commentRepository.Add(c);
            var commentDto = _mapper.Map<CommentDTO>(comment);

            return commentDto;
        }

        public CommentDTO UpdateComment(CommentRequest cr)
        {
            var c = new Comment()
            {
                Content = cr.Content,
                LastEditDate = DateTime.UtcNow
            };

            var comment = _commentRepository.Update(c);
            var commentDto = _mapper.Map<CommentDTO>(comment);

            return commentDto;
        }

        public void DeleteComment(int id)
        {
            _commentRepository.Delete(id);
        }
    }
}