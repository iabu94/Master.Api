using System.Collections.Generic;

namespace MRX.Master.Domain.Models
{
    public class User : BaseEntity<long>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string NIC { get; set; }

        public virtual IList<UserChoice> UserChoices { get; set; }
    }
}
