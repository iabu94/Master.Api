using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;

namespace MRX.Master.Data.Repositories
{
    public class GradeRepository : DefaultRepository<Grade, int>, IGradeRepository
    {
        public GradeRepository(MasterContext context) : base(context)
        {
        }
    }
}
