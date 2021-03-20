using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;

namespace MRX.Master.Data.Repositories
{
    public class SectionRepository : DefaultRepository<Section, long>, ISectionRepository
    {
        public SectionRepository(MasterContext context) : base(context)
        {
        }
    }
}
