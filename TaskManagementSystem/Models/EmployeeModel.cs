namespace TaskManagementSystem.Models
{
    public class EmployeeModel
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public string Department { get; set; } = null!;
    }
}
