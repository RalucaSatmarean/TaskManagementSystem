using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class ProjectTask
    {
        public ProjectTask()
        {
            Comments = new HashSet<Comment>();
        }

        public Guid TaskId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Reporter { get; set; }
        public Guid? Assignee { get; set; }

        public virtual Employee? AssigneeNavigation { get; set; }
        public virtual Project Project { get; set; } = null!;
        public virtual Employee ReporterNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
