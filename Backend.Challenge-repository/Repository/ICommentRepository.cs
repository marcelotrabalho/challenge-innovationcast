using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Backend.Challenge_repository.Model;

namespace Backend.Challenge_repository.Repository
{
    public interface ICommentRepository
    {
        public void Add(CommentModel comment);
        public IList<CommentModel> Get(Expression<Func<CommentModel, bool>> condicao = null, int totalResults = 0, int sizePage = 10);
        public IList<CommentModel> GetAllGrouped(int totalResults = 0, int sizePage = 10);
    }
}
