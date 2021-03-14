using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class ChoiceInfo : BaseEntity<long>
    {
        public long QuestionId { get; set; }
        public string Choice { get; set; }
        public bool IsAnswer { get; set; }

        public virtual QuestionInfo Question { get; set; }
        public IList<UserChoice> UserChoices { get; set; }
    }
}
