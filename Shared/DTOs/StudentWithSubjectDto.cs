using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public record StudentWithSubjectDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string? ImageURL { get; set; }
        public List<SubjectDto> Subjects { get; set; }
    }
}
