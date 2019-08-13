

using System;
using System.Collections.Generic;

namespace Archysoft.Data.Entities
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }    
        public ICollection<UserProfile> UserProfiles { get; set; }
    }
}
