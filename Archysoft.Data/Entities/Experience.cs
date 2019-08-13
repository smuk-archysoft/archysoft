using System;

namespace Archysoft.Data.Entities
{
    public class Experience
    {
        public Guid Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
