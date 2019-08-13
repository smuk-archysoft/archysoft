

using System;
using System.Collections.Generic;

namespace Archysoft.Data.Entities
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserProfileLanguage> UserProfileLanguages { get; set; }
    } 
}
