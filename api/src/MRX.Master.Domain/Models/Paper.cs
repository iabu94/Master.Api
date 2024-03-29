﻿using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class Paper : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeInMinutes { get; set; }
        public int Marks { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }

        public virtual GradeSubject GradeSubject { get; set; }
        public virtual IList<Section> Sections { get; set; }
    }
}
