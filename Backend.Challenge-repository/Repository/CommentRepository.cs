using System.Collections.Generic;
using Backend.Challenge_repository.Model;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace Backend.Challenge_repository.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly InnovationCastContext _contexto;
        public CommentRepository(InnovationCastContext contexto)
        {
            _contexto = contexto;
        }
        public void Add(CommentModel comment)
        {
            _contexto.Comments.Add(comment);
            _contexto.SaveChanges();
        }
        public IList<CommentModel> Get(Expression<Func<CommentModel,bool>> condicao = null, int totalResults = 0, int sizePage = 10)
        {
            var tamanho = totalResults + sizePage;
            var query = condicao == null ? 
                    _contexto.Comments.OrderByDescending(x => x.Publicacao).Take(tamanho) 
                : 
                    _contexto.Comments.Where(condicao).OrderByDescending(x => x.Publicacao).Take(tamanho);
            
            return query.ToList();
        }

        
        public IList<CommentModel> GetAllGrouped(int totalResults = 0, int sizePage = 10)
        {
            var query = _contexto.Comments.Select(c => c.Entidade).Distinct<string>().ToList();
            IList<CommentModel> list = new List<CommentModel>();

            foreach (var item in query)
            {
                foreach (var entidade in Get(x => x.Entidade == item, totalResults, sizePage))
                {
                    list.Add(new CommentModel
                    {
                        Entidade = entidade.Entidade,
                        Autor = entidade.Autor,
                        Id = entidade.Id,
                        Publicacao = entidade.Publicacao,
                        Texto = entidade.Texto
                    }
                    );
                }  
            }
            return list;

        }
    }
}
