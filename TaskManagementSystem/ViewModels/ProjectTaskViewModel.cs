using Microsoft.EntityFrameworkCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repository;

namespace TaskManagementSystem.ViewModels
{
    public class ProjectTaskViewModel
    {
        public Guid TaskId { get; set; }

        [StringLength(250, ErrorMessage = " String too long (max. 250 chars")]
        public string Name { get; set; } = null!;

        [StringLength(500, ErrorMessage = " String too long (max. 500 chars")]
        public string? Description { get; set; }

        [StringLength(100, ErrorMessage = " String too long (max. 100 chars")]
        public string? Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        public Guid ProjectId { get; set; }
        public Guid Reporter { get; set; }
        public Guid? Assignee { get; set; }
        public string ProjectName { get; set; }
        public string ReporterName { get; set; }
        public string AssigneeName { get; set; }
        public List<ProjectModel> ProjectList { get; set; }
        public List<EmployeeModel> EmployeeList { get; set; }
        public List<CommentModel> CommentList { get; set; }
        public string? Comments { get; set; }
    }
}
