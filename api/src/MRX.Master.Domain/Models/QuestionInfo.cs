using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class QuestionInfo : BaseEntity<long>
    {
        public string No { get; set; }
        public string Question { get; set; }
        public double Marks { get; set; }
        public long SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual IList<ChoiceInfo> Choices { get; set; }
    }
}
