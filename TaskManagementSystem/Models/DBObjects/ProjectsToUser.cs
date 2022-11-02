using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class ProjectsToUser
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual UserProfile User { get; set; } = null!;
    }
}
