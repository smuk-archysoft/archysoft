
using System;

namespace Archysoft.Data.Entities
{
    public class UserProfileLanguage
    {
        public Guid UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public Guid LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
