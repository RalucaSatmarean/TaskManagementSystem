using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class Project
    {
        public Project()
        {
            ProjectsToUsers = new HashSet<ProjectsToUser>();
            Tasks = new HashSet<Task>();
        }

        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual ICollection<ProjectsToUser> ProjectsToUsers { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
