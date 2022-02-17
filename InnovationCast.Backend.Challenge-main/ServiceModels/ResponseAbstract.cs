using System;

namespace Backend.Challenge.ServiceModels
{
    public class ResponseAbstract
    {
        public int? TotalResults { get; set; }
        public int? SizeByPage { get; set; }
        public DateTime? TimeStamp { get; set; }
    }
}
