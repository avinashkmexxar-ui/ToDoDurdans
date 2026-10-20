using AutoMapper;
using Domain.Entity;
using Shared.DTOs;

namespace API.Helper
{
    public sealed class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, StudentCreateDto>();

            CreateMap<Student, StudentWithSubjectDto>();
            CreateMap<Subject, SubjectDto>();
        }
       
    }
}
