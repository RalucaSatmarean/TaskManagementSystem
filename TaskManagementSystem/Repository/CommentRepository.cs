using TaskManagementSystem.Data;
using TaskManagementSystem.Models.DBObjects;
using TaskManagementSystem.Models;
using System.Reflection.Metadata.Ecma335;

namespace TaskManagementSystem.Repository
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public CommentRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public CommentRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private CommentModel MapDBobjectToModel(Comment dbobject)
        {
            var model = new CommentModel();
            if (dbobject != null)
            {
                model.CommentId = dbobject.CommentId;
                model.Comments = dbobject.Comments;
                model.Date = dbobject.Date;
                model.TaskId = dbobject.TaskId;
                model.EmployeeId = dbobject.EmployeeId;

            }
            return model;
        }
        private Comment MapModelToDbObject(CommentModel model)
        {
            var dbobject = new Comment();
            if (model != null)
            {
                dbobject.CommentId = model.CommentId;
                dbobject.Comments = model.Comments;
                dbobject.Date = model.Date;
                dbobject.TaskId = model.TaskId;
                dbobject.EmployeeId = model.EmployeeId;

            }
            return dbobject;
        }
        public List<CommentModel> GetAllComments()
        {
            var list = new List<CommentModel>();
            foreach (var dbobject in _DBContext.Comments)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }
            return list;
        }

        public CommentModel GetCommentById(Guid id)
        {
            return MapDBobjectToModel(_DBContext.Comments.FirstOrDefault(x => x.CommentId == id));
        }

        public List<CommentModel> GetCommentsByTask(Guid id)
        {
            var list = new List<CommentModel>();
            var comments = _DBContext.Comments.Where(x => x.TaskId == id).ToList();
            foreach (var dbobject in comments)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }

            return list;
        }

        
        public void InsertComment(CommentModel model)
        {
            model.CommentId = Guid.NewGuid();
            model.Date = DateTime.Now.Date;
            _DBContext.Comments.Add(MapModelToDbObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateComment(CommentModel model)
        {
            var dbobject = _DBContext.Comments.FirstOrDefault(x => x.CommentId == model.CommentId);
            if (dbobject != null)
            {
                dbobject.CommentId = model.CommentId;
                dbobject.Comments = model.Comments;
                dbobject.Date = model.Date;
                dbobject.TaskId = model.TaskId;
                dbobject.EmployeeId = model.EmployeeId;

                _DBContext.SaveChanges();
            }
        }

        public void DeleteComment(Guid id)
        {
            var dbobject = _DBContext.Comments.FirstOrDefault(x => x.CommentId == id);
            if (dbobject != null)
            {
                _DBContext.Comments.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
