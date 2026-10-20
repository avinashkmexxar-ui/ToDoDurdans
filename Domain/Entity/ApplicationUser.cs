using Domain.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Domain.Entity
{
    public enum Gender
    {
        Male,
        Female,
    }
    public class ApplicationUser : BaseIdentityUserEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int ContactNo { get; set; } 

    }
}
