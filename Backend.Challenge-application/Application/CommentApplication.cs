using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Backend.Challenge_application.Dtos;
using Backend.Challenge_application.Interfaces;
using Backend.Challenge_repository.Model;
using Backend.Challenge_repository.Repository;

namespace Backend.Challenge_application.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public CommentDto Add(CommentDto comment)
        {
            var commentModel = new CommentModel
            {
                Autor = comment.Autor,
                Entidade = comment.Entidade,
                Id = comment.Id,
                Publicacao = comment.DataDePublicacao ?? DateTime.Now,
                Texto = comment.CampoTexto
            };

            _commentRepository.Add(commentModel);
            
            comment.Id = commentModel.Id;

            return comment;
        }

        public IList<CommentDto> GetAllGrouped(int totalResults = 0, int sizeByPage = 10)
        {
            return (from p in _commentRepository.GetAllGrouped(totalResults, sizeByPage)
                    select new CommentDto()
                    {
                        Autor = p.Autor,
                        CampoTexto = p.Texto,
                        DataDePublicacao = p.Publicacao,
                        Entidade = p.Entidade,
                        Id = p.Id
                    }).ToList();
        }

        public IList<CommentDto> Get(string entidade, int totalResults = 0, int sizePage = 10 )
        {
            Expression<Func<CommentModel, bool>> query = x => x.Entidade == entidade;

            return (from p in _commentRepository.Get(query, totalResults, sizePage)
                    select new CommentDto()
                    {
                        Autor = p.Autor,
                        CampoTexto = p.Texto,
                        DataDePublicacao = p.Publicacao,
                        Entidade = p.Entidade,
                        Id = p.Id
                    }).ToList();
        }
    }
}
