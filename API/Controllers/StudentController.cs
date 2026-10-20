using Domain.interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Transport.NamedPipes;
using Shared.DTOs;

namespace API.Controllers
{
    [ApiController] 
    [Route("api/students")]
    public class StudentController : Controller
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices) => _studentServices = studentServices;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseDto<IReadOnlyList<StudentDto>>>> CreateStudent(
            StudentCreateDto studentCreateDto)
        {
            var response = await _studentServices.CreateStudent(studentCreateDto);
            return StatusCode(response.Code, response);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseDto<IReadOnlyList<StudentDto>>>> GetAll()
        {
            var response = await _studentServices.GetStudentWithSubjects();
            return StatusCode(response.Code, response);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseDto<IReadOnlyList<StudentDto>>>> GetParticularStudent(Guid id)
        {
            var response = await _studentServices.GetParticularStudentWithSubjects(id);
            return StatusCode(response.Code, response);
        }
    }
}
