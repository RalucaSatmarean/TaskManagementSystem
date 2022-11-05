using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class ProjectModel
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}
