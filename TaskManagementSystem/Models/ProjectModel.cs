using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class ProjectModel
    {
        public Guid ProjectId { get; set; }

        [StringLength(250, ErrorMessage = " String too long (max. 250 chars")]
        public string Title { get; set; } = null!;

        [StringLength(500, ErrorMessage = " String too long (max. 500 chars")]
        public string? Description { get; set; }

        [StringLength(100, ErrorMessage = " String too long (max. 100 chars")]
        public string? Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}
