using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.ViewModels
{
    public class ProjectTaskEditableViewModel : ProjectTaskViewModel
    {
        public List<SelectListItem> TaskStatusesList = new List<SelectListItem> {
           new SelectListItem { Text = "Open", Value = "Open" },
           new SelectListItem { Text = "To Do", Value = "To Do" },
           new SelectListItem { Text = "In Progress", Value = "In Progress" },
           new SelectListItem { Text = "Done", Value = "Done" },
           new SelectListItem { Text = "Cancelled" , Value = "Cancelled" }
        };
      
        public string? SelectedTaskStatus { get; set; }

        public ProjectTaskEditableViewModel(ProjectTaskViewModel baseViewModel)
        {
            this.TaskId = baseViewModel.TaskId;
            this.Name = baseViewModel.Name;
            this.Description = baseViewModel.Description;
            this.Status = baseViewModel.Status;
            this.StartDate = baseViewModel.StartDate;
            this.ProjectId = baseViewModel.ProjectId;
            this.Reporter = baseViewModel.Reporter;
            this.Assignee = baseViewModel.Assignee;
            this.ProjectName = baseViewModel.ProjectName;
            this.ReporterName = baseViewModel.ReporterName;
            this.AssigneeName = baseViewModel.AssigneeName;
            this.ProjectList = baseViewModel.ProjectList;
            this.EmployeeList = baseViewModel.EmployeeList;
            this.CommentList = baseViewModel.CommentList;
            this.Comments = baseViewModel.Comments;
        }
    }
}
