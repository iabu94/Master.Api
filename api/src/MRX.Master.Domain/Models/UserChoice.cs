namespace MRX.Master.Domain.Models
{
    public class UserChoice : BaseEntity<long>
    {
        public long UserId { get; set; }
        public long ChoiceId { get; set; }

        public User User { get; set; }
        public ChoiceInfo Choice { get; set; }
    }
}
