namespace MRX.Master.Domain.Models
{
    public class UserChoice : BaseEntity<long>
    {
        public long UserId { get; set; }
        public long ChoiceId { get; set; }

        public virtual User User { get; set; }
        public virtual ChoiceInfo Choice { get; set; }
    }
}
