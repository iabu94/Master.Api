using System;
using System.Threading.Tasks;

namespace MRX.Master.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task SaveChangesAsync();
    }
}
