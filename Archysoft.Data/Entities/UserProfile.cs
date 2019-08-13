using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Archysoft.Data.Entities
{
    public class UserProfile
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
        public string Skype { get; set; }

        public byte[] Photo { get; set; }      

        public Description Description { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }

        public ICollection<UserProfileLanguage> UserProfileLanguages { get; set; }

        public ICollection<UserProfileSkill> UserProfileSkills { get; set; }
       
        public Guid CityId { get; set; }
        
        public City City { get; set; }    
        public User User { get; set; }
            
    }
}
