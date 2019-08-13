

using System;

namespace Archysoft.Domain.Model.Model.Employees
{
    public class ExperienceModel
    {
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
    }
}
