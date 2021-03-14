using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;

namespace MRX.Master.Data.Repositories
{
    public class QuestionRepository : DefaultRepository<QuestionInfo, long>, IQuestionRepository
    {
    }
}
