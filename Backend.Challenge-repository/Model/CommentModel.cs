using System;

namespace Backend.Challenge_repository.Model
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Entidade { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }
        public DateTime Publicacao { get; set; }
    }
}
