using System;

namespace Archysoft.Data.Entities
{
    public class UserProfileSkill
    {
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
