using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class Employee
    {
        public Employee()
        {
            Comments = new HashSet<Comment>();
            EmployeesToProjects = new HashSet<EmployeesToProject>();
            ProjectTaskAssigneeNavigations = new HashSet<ProjectTask>();
            ProjectTaskReporterNavigations = new HashSet<ProjectTask>();
        }

        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Department { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EmployeesToProject> EmployeesToProjects { get; set; }
        public virtual ICollection<ProjectTask> ProjectTaskAssigneeNavigations { get; set; }
        public virtual ICollection<ProjectTask> ProjectTaskReporterNavigations { get; set; }
    }
}
