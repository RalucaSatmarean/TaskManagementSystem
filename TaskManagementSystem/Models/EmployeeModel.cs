using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class EmployeeModel
    {
        public Guid EmployeeId { get; set; }

        [StringLength(250, ErrorMessage = " String too long (max. 250 chars")]
        public string Name { get; set; } = null!;

        [StringLength(250, ErrorMessage = " String too long (max. 250 chars")]
        public string JobTitle { get; set; } = null!;

        [StringLength(250, ErrorMessage = " String too long (max. 250 chars")]
        public string Department { get; set; } = null!;
    }
}
