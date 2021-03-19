using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;

namespace MRX.Master.Data.Repositories
{
    public class SectionTypeRepository : DefaultRepository<SectionType, int>, ISectionTypeRepository
    {
        public SectionTypeRepository(MasterContext context) : base(context)
        {
        }
    }
}
