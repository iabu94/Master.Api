using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class ChoiceInfo : BaseEntity<long>
    {
        public string Choice { get; set; }
        public bool IsAnswer { get; set; }
        public long QuestionId { get; set; }

        public virtual QuestionInfo Question { get; set; }
        public virtual IList<UserChoice> UserChoices { get; set; }
    }
}
