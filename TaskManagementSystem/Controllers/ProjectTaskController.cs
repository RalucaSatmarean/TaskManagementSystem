using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repository;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Controllers
{
    public class ProjectTaskController : Controller
    {

        private Repository.ProjectTaskRepository _repository;
        private Repository.ProjectRepository _projectRepository;
        private Repository.EmployeeRepository _employeeRepository;
        private Repository.CommentRepository _commentRepository;

        public ProjectTaskController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ProjectTaskRepository(dbContext);
            _projectRepository = new ProjectRepository(dbContext);
            _employeeRepository = new EmployeeRepository(dbContext);
            _commentRepository = new CommentRepository(dbContext);

        }

        // GET: ProjectTaskController
        public ActionResult Index()
        {
            var tasks = _repository.GetAllTasks();
            var viewModelList = new List<ProjectTaskViewModel>();
            foreach(var task in tasks)
            {
                viewModelList.Add(PopulateViewModel(task));
            }
            return View(viewModelList);
        }

        // GET: ProjectTaskController/Details/5
        public ActionResult Details(Guid id)
        {
            var task = _repository.GetTaskById(id);
            var viewModel = PopulateViewModelWithComment(task);
            return View("ProjectTaskDetails", viewModel);

        }

        // GET: ProjectTaskController/Create
        public ActionResult Create()
        {
            var task = new ProjectTaskModel();
            var viewmodel = PopulateViewModel(task);
            return View("CreateProjectTask",viewmodel);
        }

        // POST: ProjectTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ProjectTaskModel model = new ProjectTaskModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertTask(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProjectTask");
            }
        }

        // GET: ProjectTaskController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetTaskById(id);
            return View("EditProjectTask", model);
        }

        // POST: ProjectTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ProjectTaskModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateTask(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }


        // GET: ProjectTaskController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetTaskById(id);
            return View("DeleteProjectTask", model);
        }

        // POST: ProjectTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteTask(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProjectTask", id);
            }
        }

        private ProjectTaskViewModel PopulateViewModel(ProjectTaskModel task)
        {
            var result = new ProjectTaskViewModel();
            result.TaskId = task.TaskId;
            result.Name = task.Name;
            result.Description = task.Description;
            result.Status = task.Status;
            result.ProjectId = task.ProjectId;
            result.Reporter = task.Reporter;
            result.Assignee = task.Assignee;
            result.StartDate = task.StartDate;
            var project = _projectRepository.GetProjectById(task.ProjectId);
            result.ProjectName = project.Title;
            var reporter = _employeeRepository.GetEmployeeById(task.Reporter);
            result.ReporterName = reporter.Name;
            var assignee = _employeeRepository.GetEmployeeById(task.Assignee);
            result.AssigneeName = assignee.Name;
            result.ProjectList = _projectRepository.GetAllProjects();
            result.EmployeeList = _employeeRepository.GetAllEmployees();
            return result;
        }

        private ProjectTaskViewModel PopulateViewModelWithComment(ProjectTaskModel task)
        {
            var result = PopulateViewModel(task);
            result.CommentList = _commentRepository.GetCommentsByTask(task.TaskId);
            result.Comments = PopulateComments(result.CommentList);
            return result;
        }



        private string PopulateComments(List<CommentModel> commentList)
        {
            string result = string.Empty;
            if (commentList != null)
            {
                foreach (var comment in commentList)
                {
                    string userName = _employeeRepository.GetEmployeeById(comment.EmployeeId).Name;
                    string formattedComment = $"At {comment.Date.GetValueOrDefault().ToString("MM/dd/yyyy")} {userName} said: {comment.Comments};";
                    result = string.Join('\n', result, formattedComment);
                }
                return result.TrimStart('\n');
            }
            return result;
        }


    }
}
