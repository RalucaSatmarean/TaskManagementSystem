using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        private Repository.EmployeeRepository _repository;

        public EmployeeController (ApplicationDbContext dbContext )
        {
            _repository = new Repository.EmployeeRepository(dbContext);
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            var employees = _repository.GetAllEmployees();
            return View("Index", employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetEmployeeById(id);
            return View("EmployeeDetails", model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View("CreateEmployee");
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.EmployeeModel model = new Models.EmployeeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.InsertEmployee(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateEmployee");
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetEmployeeById(id);
            return View("EditEmployee", model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new EmployeeModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateEmployee(model);
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetEmployeeById(id);
            return View("DeleteEmployee", model);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteEmployee(id);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("DeleteEmployee", id);

            }
        }
    }
}
