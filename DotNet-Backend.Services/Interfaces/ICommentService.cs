using System.Collections.Generic;
using DotNet_Backend.Data.Contracts.DTO;
using DotNet_Backend.Data.Contracts.Requests;

namespace DotNet_Backend.Services.Interfaces
{
    public interface ICommentService
    {
        List<CommentDTO> GetAll();
        List<CommentDTO> GetAllFromUser(int userId);
        List<CommentDTO> GetAllFromPost(int postId);
        CommentDTO GetComment(int id);
        CommentDTO AddComment(CommentRequest cr);
        CommentDTO UpdateComment(CommentRequest cr);
        void DeleteComment(int id);

    }
}