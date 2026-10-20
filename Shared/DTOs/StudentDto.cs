using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.DTOs
{
    public class StudentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string? ImageURL { get; set; }
    }
}
