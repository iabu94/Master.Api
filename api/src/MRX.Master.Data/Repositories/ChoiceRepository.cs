using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;

namespace MRX.Master.Data.Repositories
{
    public class ChoiceRepository : DefaultRepository<ChoiceInfo, long>, IChoiceRepository
    {
        public ChoiceRepository(MasterContext context) : base(context)
        {
        }
    }
}
