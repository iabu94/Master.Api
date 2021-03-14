using AutoMapper;
using MRX.Master.Api.DTOs;
using MRX.Master.Domain.Models;

namespace MRX.Master.Api.Mappings
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<Grade, GradeDto>()
                .ReverseMap();
            CreateMap<Subject, SubjectDto>()
                .ReverseMap();
            CreateMap<Paper, PaperDto>()
                .ReverseMap();
            CreateMap<GradeSubject, GradeSubjectDto>()
                .ReverseMap();
        }
    }
}
