using System;
using System.Collections.Generic;

namespace Archysoft.Data.Entities
{
    public class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserProfileSkill> UserProfileSkills { get; set; }      
    }
}
