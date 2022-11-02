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
        public Guid UserId { get; set; }

        public virtual Task Task { get; set; } = null!;
        public virtual UserProfile User { get; set; } = null!;
    }
}
