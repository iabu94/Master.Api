using Microsoft.EntityFrameworkCore;
using MRX.Master.Domain.Contracts;
using MRX.Master.Domain.Models;
using System.Reflection;
using System.Threading.Tasks;

namespace MRX.Master.Data
{
    public class MasterContext : DbContext, IUnitOfWork
    {
        public MasterContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(GetType()));
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<GradeSubject> GradeSubjects { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionType> SectionTypes { get; set; }
        public DbSet<QuestionInfo> Questions { get; set; }
        public DbSet<ChoiceInfo> Choices { get; set; }
        public DbSet<UserChoice> UserChoices { get; set; }
        public DbSet<User> Users { get; set; }

        public async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }
    }
}
