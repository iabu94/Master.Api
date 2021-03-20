using Microsoft.Extensions.DependencyInjection;
using MRX.Master.Data;
using MRX.Master.Data.Repositories;
using MRX.Master.Domain.Contracts;

namespace MRX.Master.Api.Extensions
{
    public static class DependencyContainerExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, MasterContext>(s => s.GetService<MasterContext>());
            services.AddScoped<IChoiceRepository, ChoiceRepository>();
            services.AddScoped<IGradeRepository, GradeRepository>();
            services.AddScoped<IGradeSubjectRepository, GradeSubjectRepository>();
            services.AddScoped<IPaperRepository, PaperRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<ISectionTypeRepository, SectionTypeRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserChoiceRepository, UserChoiceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
