using System;
using System.Collections.Generic;

namespace TaskManagementSystem.Models.DBObjects
{
    public partial class Comment
    {
        public Guid CommentId { get; set; }
        public string Comments { get; set; } = null!;
        public DateTime? Date { get; set; }
        public Guid TaskId { get; set; }
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual ProjectTask Task { get; set; } = null!;
    }
}
