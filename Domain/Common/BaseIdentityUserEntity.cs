using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class BaseIdentityUserEntity : IdentityUser<Guid>
    {
    }
}
