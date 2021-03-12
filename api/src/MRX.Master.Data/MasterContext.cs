using Microsoft.EntityFrameworkCore;
using MRX.Master.Domain.Contracts;
using System.Threading.Tasks;

namespace MRX.Master.Data
{
    public class MasterContext : DbContext, IUnitOfWork
    {
        public MasterContext(DbContextOptions options) : base(options)
        {

        }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
