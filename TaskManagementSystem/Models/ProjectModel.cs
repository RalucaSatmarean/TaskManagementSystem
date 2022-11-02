namespace TaskManagementSystem.Models
{
    public class ProjectModel
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Status { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
