using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class GradeSubject : BaseEntity<int>
    {
        public int GradeId { get; set; }
        public int SubjectId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual IList<Paper> Papers { get; set; }
    }
}
