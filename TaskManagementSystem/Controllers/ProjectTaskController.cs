using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class ProjectTaskController : Controller
    {

        private Repository.ProjectTaskRepository _repository;

        public ProjectTaskController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.ProjectTaskRepository(dbContext);
        }

        // GET: ProjectTaskController
        public ActionResult Index()
        {
            var tasks = _repository.GetAllTasks();
            return View("Index", tasks);
        }

        // GET: ProjectTaskController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetTaskById(id);
            return View("ProjectTaskDetails", model);

        }

        // GET: ProjectTaskController/Create
        public ActionResult Create()
        {
            return View("CreateProjectTask");
        }

        // POST: ProjectTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.ProjectTaskModel model = new Models.ProjectTaskModel();
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
    }
}
