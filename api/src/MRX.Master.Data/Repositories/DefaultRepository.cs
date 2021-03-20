using Microsoft.EntityFrameworkCore;
using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRX.Master.Data.Repositories
{
    public abstract class DefaultRepository<T, K> : IRepository<T> where T : BaseEntity<K> where K : struct
    {
        protected MasterContext Context { get; }

        public DefaultRepository(MasterContext context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            entity.Deleted = true;
            Context.Set<T>().Update(entity);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Context.Set<T>()
                .Where(e => !e.Deleted).ToListAsync();
        }

        public async Task<T> GetAsync(object id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
