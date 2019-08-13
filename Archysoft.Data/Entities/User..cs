using System;
using Microsoft.AspNetCore.Identity;

namespace Archysoft.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public UserProfile Profile { get; set; }
    }
}
