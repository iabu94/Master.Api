using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;

namespace MRX.Master.Data.Repositories
{
    public class UserChoiceRepository : DefaultRepository<UserChoice, long>, IUserChoiceRepository
    {
        public UserChoiceRepository(MasterContext context) : base(context)
        {
        }
    }
}
