using System.Collections.Generic;
using System.Linq;
using Backend.Challenge.ServiceModels;
using Backend.Challenge_application.Dtos;
using Backend.Challenge_application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Challenge.Controllers
{
    public class MainController : Controller
    {
        private readonly ICommentApplication _commentApplication;

        public MainController(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        // This action responds to the url /main/users/42 and /main/users?id=4&id=10
        public GetUserResponse Users(int[] id)
        {
            return new GetUserResponse
            {
                Users = id.ToDictionary(i => i, i => new UserDto
                {
                    Id = i,
                    Username = $"User {i}",
                    Email = $"user-{i}@example.com"
                })
            };
        }

        // TODO: An action to return a paged list of comments
        [HttpGet]
        public CommentResponse Comments(string entidade, int totalResults = 0, int sizeByPage = 10)
        {
            if (string.IsNullOrEmpty(entidade))
            {
                return new CommentResponse();
            }

            var result = _commentApplication.Get(entidade, totalResults, sizeByPage);

            return new CommentResponse() 
            { 
                SizeByPage = sizeByPage,
                TimeStamp  = System.DateTime.Now,
                TotalResults = result.Count,
                Comments = ReturnCommentsByEntity(result) 
            };
        }

        [HttpGet]
        public CommentResponse CommentsAll(int totalResults = 0, int sizeByPage = 10)
        {
            var result = _commentApplication.GetAllGrouped(totalResults, sizeByPage);
            return new CommentResponse()
            {
                SizeByPage = sizeByPage,
                TotalResults = result.Count,
                TimeStamp = System.DateTime.Now,
                Comments = ReturnCommentsByEntity(result)
            };
            
        }
        // TODO: An action to add a comment
        [HttpPost]
        public ActionResult<CommentResponse> CommentsAdd([FromBodyAttribute] ComentRequest response)
        {
            if (response == null)
            {
                return new CommentResponse();
            }

            var commentApplication = _commentApplication.Add(new CommentDto()
            {
                CampoTexto = response.Texto,
                Autor = response.Autor,
                DataDePublicacao = response.Publicacao ?? System.DateTime.Now,
                Entidade = response.Entidade
            });
            return Ok( new CommentResponse() 
                {
                    SizeByPage = 1,
                    TotalResults = 1,
                    TimeStamp = System.DateTime.Now,
                    Comments = ReturnCommentsByEntity(
                        new List<CommentDto>() 
                            { 
                                commentApplication 
                            }
                    ) 
                });
        }

        private Dictionary<string, List<CommentDto>> ReturnCommentsByEntity(IList<CommentDto> comments)
        {
            var result = comments?.ToList()
                .GroupBy(x => x.Entidade)
                .Select(i => new
                {
                    Entidade = i.Key.ToString(),
                    Comments = i.OrderByDescending(y => y.DataDePublicacao).ToList()
                });

            return result.ToDictionary(x => x.Entidade, x => x.Comments);
        }
    }
}