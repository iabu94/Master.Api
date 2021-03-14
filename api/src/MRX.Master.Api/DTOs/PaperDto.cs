using System.Collections.Generic;

namespace MRX.Master.Api.DTOs
{
    public class PaperDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeInMinutes { get; set; }
        public int Marks { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
    }
}
