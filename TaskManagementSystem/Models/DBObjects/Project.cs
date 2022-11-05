using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class Project
    {
        public Project()
        {
            EmployeesToProjects = new HashSet<EmployeesToProject>();
            ProjectTasks = new HashSet<ProjectTask>();
        }

        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual ICollection<EmployeesToProject> EmployeesToProjects { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
    }
}
