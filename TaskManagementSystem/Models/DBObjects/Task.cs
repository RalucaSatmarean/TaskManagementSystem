using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
        }

        public Guid TaskId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Reporter { get; set; }
        public Guid? Assignee { get; set; }
        public DateTime? StartDate { get; set; }

        public virtual UserProfile? AssigneeNavigation { get; set; }
        public virtual Project Project { get; set; } = null!;
        public virtual UserProfile ReporterNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
