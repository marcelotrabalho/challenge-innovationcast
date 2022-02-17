using System.Collections.Generic;
using Backend.Challenge_application.Dtos;

namespace Backend.Challenge_application.Interfaces
{
    public interface ICommentApplication
    {
        public IList<CommentDto> GetAllGrouped(int totalResults = 0, int sizeByPage = 10);
        public IList<CommentDto> Get(string entidade, int totalResults = 0, int sizePage = 10);
        public CommentDto Add(CommentDto comment);
    }
}
