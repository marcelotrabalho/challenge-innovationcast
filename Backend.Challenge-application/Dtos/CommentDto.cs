using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge_application.Dtos
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Entidade { get; set; }
        public string Autor { get; set; }
        public string CampoTexto { get; set; }
        public DateTime? DataDePublicacao { get; set; }
    }
}
