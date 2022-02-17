using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.ServiceModels
{
    public class ComentRequest
    {
        public string Entidade { get; set; }
        public string Autor { get; set; }
        public string Texto { get; set; }
        public DateTime? Publicacao { get; set; }
    }
}
