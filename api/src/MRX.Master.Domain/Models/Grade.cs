using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class Grade : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual IList<Paper> Papers { get; set; }
    }
}
