using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class SectionType : BaseEntity<int>
    {
        public string Type { get; set; }

        public virtual IList<Section> Sections { get; set; }
    }
}
