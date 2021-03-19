using System.ComponentModel.DataAnnotations;

namespace MRX.Master.Api.DTOs
{
    public class GradeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
