using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers
{
    public class CommentController : Controller
    {

        private Repository.CommentRepository _repository;

        public CommentController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.CommentRepository(dbContext);
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
