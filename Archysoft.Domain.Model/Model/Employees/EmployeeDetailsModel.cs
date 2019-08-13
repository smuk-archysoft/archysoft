using System;
using System.Collections.Generic;


namespace Archysoft.Domain.Model.Model.Employees
{
    //UserProfile is temp model. Must be new Table with ref to User;
    public class EmployeeDetailsModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public byte[] Photo { get; set; }
        public DescriptionModel Description { get; set; }
        public List<EducationModel> Educations { get; set; }
        public List<ExperienceModel> Experiences{ get; set; }

        public List<string> Skills { get; set; }
        public List<string> Languages { get; set; }

        public EmployeeDetailsModel()
        {
            Skills = new List<string>();
            Languages = new List<string>();
            Educations = new List<EducationModel>();
            Experiences = new List<ExperienceModel>();
        }

    }
}
