using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class TaskModel
    {
        public Guid TaskId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Reporter { get; set; }
        public Guid? Assignee { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}
