using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementSystem.Controllers
{
    public class ProjectTaskController : Controller
    {
        // GET: ProjectTaskController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProjectTaskController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectTaskController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectTaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectTaskController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectTaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectTaskController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectTaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
