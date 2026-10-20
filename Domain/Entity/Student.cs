using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Student : BaseEntity
    {
        []
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string? ImageURL { get; set; }
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    }
}
