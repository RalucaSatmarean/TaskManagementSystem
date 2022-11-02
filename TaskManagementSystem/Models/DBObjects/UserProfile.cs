using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Comments = new HashSet<Comment>();
            ProjectsToUsers = new HashSet<ProjectsToUser>();
            TaskAssigneeNavigations = new HashSet<Task>();
            TaskReporterNavigations = new HashSet<Task>();
        }

        public Guid UserId { get; set; }
        public string Name { get; set; } = null!;
        public string JobTitle { get; set; } = null!;

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ProjectsToUser> ProjectsToUsers { get; set; }
        public virtual ICollection<Task> TaskAssigneeNavigations { get; set; }
        public virtual ICollection<Task> TaskReporterNavigations { get; set; }
    }
}
