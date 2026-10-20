using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
    }
}
