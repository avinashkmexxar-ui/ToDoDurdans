using Domain.Entity;
using Domain.interfaces;
using Domain.interfaces.Services;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Infrastructure.Services
{
    public class StudentService : IStudentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDto<StudentDto>> CreateStudent(StudentCreateDto studentCreateDto)
        {
            Student student = new();
            student = _mapper.Map<Student>(studentCreateDto);
            await _unitOfWork.Student.AddAsync(student);
            _unitOfWork.SaveAsync();
            return ResponseDto<StudentDto>.Success(_mapper.Map<StudentDto>(student)); 
        }

        public async Task<ResponseDto<StudentWithSubjectDto>> GetParticularStudentWithSubjects(Guid id)
        {
            var student = await _unitOfWork.Student.GetFirstOrDefaultAsync(a => a.Id == id,
                     includeProperties: "Subjects"
                 );
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {id} was not found.");
            }

            var studentDto = new StudentWithSubjectDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Address = student.Address,
                ImageURL = student.ImageURL,
                Subjects = student.Subjects.Select(s => new SubjectDto
                {
                    Name = s.Name
                }).ToList()
            };
            return ResponseDto<StudentWithSubjectDto>.Success(studentDto);
        }

        public async Task<ResponseDto<List<StudentWithSubjectDto>>> GetStudentWithSubjects()
        {
            var students = await _unitOfWork.Student.GetAllAsync(includeProperties: "Subjects");
            if (students == null)
            {
                throw new KeyNotFoundException($"Student with ID  was not found.");
            } 
            var studentDtos = _mapper.Map<List<StudentWithSubjectDto>>(students);

            return ResponseDto<List<StudentWithSubjectDto>>.Success(studentDtos);
        }
    }
}
