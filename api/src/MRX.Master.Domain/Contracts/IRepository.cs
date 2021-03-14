using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRX.Master.Domain.Contracts
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetAsync(object id);
        Task<IList<T>> GetAllAsync();
    }
}
