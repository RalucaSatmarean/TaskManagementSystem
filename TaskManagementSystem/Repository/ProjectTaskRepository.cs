using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.DBObjects;

namespace TaskManagementSystem.Repository
{
    public class ProjectTaskRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public ProjectTaskRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ProjectTaskRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private ProjectTaskModel MapDBobjectToModel(ProjectTask dbobject)
        {
            var model = new ProjectTaskModel();
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
        private ProjectTask MapModelToDbObject(ProjectTaskModel model)
        {
            var dbobject = new ProjectTask();
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
        public List<ProjectTaskModel> GetAllTasks()
        {
            var list = new List<ProjectTaskModel>();
            foreach (var dbobject in _DBContext.ProjectTasks)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }
            return list;
        }

        public ProjectTaskModel GetTaskById(Guid id)
        {
            return MapDBobjectToModel(_DBContext.ProjectTasks.FirstOrDefault(x => x.TaskId == id));
        }

        public void InsertTask(ProjectTaskModel model)
        {
            model.TaskId = Guid.NewGuid();
            _DBContext.ProjectTasks.Add(MapModelToDbObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateTask(ProjectTaskModel model)
        {
            var dbobject = _DBContext.ProjectTasks.FirstOrDefault(x => x.TaskId == model.TaskId);
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
            var dbobject = _DBContext.ProjectTasks.FirstOrDefault(x => x.TaskId == id);
            if (dbobject != null)
            {
                _DBContext.ProjectTasks.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
