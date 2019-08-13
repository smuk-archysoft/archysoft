

using System;

namespace Archysoft.Data.Entities
{
    public class Education
    {
        public Guid Id { get; set; }
        public string School { get; set; }     
        public int YearAttendedFrom { get; set; }
        public int YearAttendedTo { get; set; }
        public string Degree { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }     
    }

   
}
