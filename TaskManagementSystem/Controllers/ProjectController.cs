using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class ProjectController : Controller
    {
       private Repository.ProjectRepository _repository;
       private Repository.ProjectTaskRepository _taskRepository;

        public ProjectController (ApplicationDbContext dbContext)
        {
            _repository = new Repository.ProjectRepository(dbContext);
            _taskRepository = new Repository.ProjectTaskRepository(dbContext);
        }


        // GET: ProjectController
        public ActionResult Index()
        {
            var projects = _repository.GetAllProjects();
            return View("Index", projects);
        }

        
        // GET: ProjectController/Details/5
        public ActionResult Details(Guid id)
        {
            var tasks = _taskRepository.GetAllTasks();
            var taskList = tasks.Select(x => new SelectListItem(x.Name, x.TaskId.ToString()));
            ViewBag.TaskCount = taskList.Count();

            var model = _repository.GetProjectById(id);
            return View("ProjectDetails", model);
        }

        // GET: ProjectController/Create
        [Authorize(Roles = "User,Admin")]
        public ActionResult Create()
        {
            return View("CreateProject");
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User,Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.ProjectModel model = new Models.ProjectModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertProject(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateProject");
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetProjectById(id);
            return View("EditProject",model);
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ProjectModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateProject(model);
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

        // GET: ProjectController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetProjectById(id);
            return View("DeleteProject", model);
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteProject(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteProject", id);
            }
        }
    }
}
