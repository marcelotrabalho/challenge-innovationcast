using System;
using System.Collections.Generic;
using Backend.Challenge_application.Dtos;

namespace Backend.Challenge.ServiceModels
{
    public class CommentResponse : ResponseAbstract
    {
        
        public Dictionary<string, List<CommentDto>> Comments { get; set; }
        
    }
}
