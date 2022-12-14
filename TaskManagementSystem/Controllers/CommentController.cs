using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Repository;

namespace TaskManagementSystem.Controllers
{
    public class CommentController : Controller
    {

        private Repository.CommentRepository _repository;
        private Repository.ProjectTaskRepository _taskRepository;
        private Repository.EmployeeRepository _employeeRepository;

        public CommentController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.CommentRepository(dbContext);
            _taskRepository = new ProjectTaskRepository(dbContext);
            _employeeRepository = new EmployeeRepository(dbContext);
         
        }

        // GET: CommentController
        public ActionResult Index()
        {
            var comments = _repository.GetAllComments();
            return View("Index", comments);
        }

        // GET: CommentController/Details/5
        public ActionResult Details(Guid id)
        {
            
            var model = _repository.GetCommentById(id);
            return View("CommentDetails", model);

        }

        // GET: CommentController/Create
        public ActionResult Create()
        {
           
            var tasks = _taskRepository.GetAllTasks();
            var taskList = tasks.Select(x => new SelectListItem(x.Name, x.TaskId.ToString()));
            ViewBag.TaskList = taskList;

            var employees = _employeeRepository.GetAllEmployees();
            var employeeList = employees.Select(x => new SelectListItem(x.Name, x.EmployeeId.ToString()));
            ViewBag.EmployeeList = employeeList;

            return View("CreateComment");
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.CommentModel model = new Models.CommentModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertComment(model);
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateComment");
            }
        }

        // GET: CommentController/Edit/5
        public ActionResult Edit(Guid id)
        {

            var tasks = _taskRepository.GetAllTasks();
            var taskList = tasks.Select(x => new SelectListItem(x.Name, x.TaskId.ToString()));
            ViewBag.TaskList = taskList;

            var model = _repository.GetCommentById(id);
            return View("EditComment", model);
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new CommentModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateComment(model);
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


        // GET: CommentController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetCommentById(id);
            return View("DeleteComment", model);
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteComment(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteComment", id);
            }
        }
    }
}
