using System;

namespace Archysoft.Data.Entities
{
    public class Description
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
