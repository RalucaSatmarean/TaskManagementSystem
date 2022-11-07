using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class ProjectTaskModel
    {
        public Guid TaskId { get; set; }

        [StringLength(250, ErrorMessage = " String too long (max. 250 chars")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = " String too long (max. 500 chars")]
        public string? Description { get; set; }

        [StringLength(100, ErrorMessage = " String too long (max. 100 chars")]
        public string? Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Reporter { get; set; }
        public Guid? Assignee { get; set; }
    }
}
