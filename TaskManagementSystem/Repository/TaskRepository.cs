using TaskManagementSystem.Data;
using TaskManagementSystem.Models.DBObjects;
using TaskManagementSystem.Models;
using Task = TaskManagementSystem.Models.DBObjects.Task;

namespace TaskManagementSystem.Repository
{
    public class TaskRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public TaskRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public TaskRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private TaskModel MapDBobjectToModel(Task dbobject)
        {
            var model = new TaskModel();
            if (dbobject != null)
            {
                model.TaskId = dbobject.TaskId;
                model.Name = dbobject.Name;
                model.Description = dbobject.Description;
                model.Status = dbobject.Status;
                model.ProjectId = dbobject.ProjectId;
                model.Reporter = dbobject.Reporter;
                model.Assignee = dbobject.Assignee;
                model.StartDate = dbobject.StartDate;
            }
            return model;
        }
        private Task MapModelToDbObject(TaskModel model)
        {
            var dbobject = new Task();
            if (model != null)
            {
                dbobject.TaskId = model.TaskId;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.Status = model.Status;
                dbobject.ProjectId = model.ProjectId;
                dbobject.Reporter = model.Reporter;
                dbobject.Assignee = model.Assignee;
                dbobject.StartDate = model.StartDate;
            }
            return dbobject;
        }
        public List<TaskModel> GetAllTasks()
        {
            var list = new List<TaskModel>();
            foreach (var dbobject in _DBContext.Tasks)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }
            return list;
        }

        public TaskModel GetTaskById(Guid id)
        {
            return MapDBobjectToModel(_DBContext.Tasks.FirstOrDefault(x => x.TaskId == id));
        }

        public void InsertTask(TaskModel model)
        {
            model.TaskId = Guid.NewGuid();
            _DBContext.Tasks.Add(MapModelToDbObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateTask(TaskModel model)
        {
            var dbobject = _DBContext.Tasks.FirstOrDefault(x => x.TaskId == model.TaskId);
            if (dbobject != null)
            {
                dbobject.TaskId = model.TaskId;
                dbobject.Name = model.Name;
                dbobject.Description = model.Description;
                dbobject.Status = model.Status;
                dbobject.ProjectId = model.ProjectId;
                dbobject.Reporter = model.Reporter;
                dbobject.Assignee = model.Assignee;
                dbobject.StartDate = model.StartDate;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteTask(Guid id)
        {
            var dbobject = _DBContext.Tasks.FirstOrDefault(x => x.TaskId == id);
            if (dbobject != null)
            {
                _DBContext.Tasks.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
