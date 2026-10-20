using Domain.Entity;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.interfaces.Services
{
    public interface IStudentServices
    {
        Task<ResponseDto<StudentDto>> CreateStudent(StudentCreateDto studentCreateDto);
        Task<ResponseDto<List<StudentWithSubjectDto>>> GetStudentWithSubjects();
        Task<ResponseDto<StudentWithSubjectDto>> GetParticularStudentWithSubjects(Guid id);
    }
}
