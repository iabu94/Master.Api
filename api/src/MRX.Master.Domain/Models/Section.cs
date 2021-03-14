using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class Section : BaseEntity<long>
    {
        public string Title { get; set; }
        public int PaperId { get; set; }
        public int SectionTypeId { get; set; }

        public virtual Paper Paper { get; set; }
        public virtual SectionType SectionType { get; set; }
        public IList<QuestionInfo> Questions { get; set; }
    }
}
