using TaskManagementSystem.Data;
using TaskManagementSystem.Models.DBObjects;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repository
{
    public class ProjectRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public ProjectRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public ProjectRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private ProjectModel MapDBobjectToModel(Project dbobject)
        {
            var model = new ProjectModel();
            if (dbobject != null)
            {
                model.ProjectId = dbobject.ProjectId;
                model.Title = dbobject.Title;
                model.Description = dbobject.Description;
                model.Status = dbobject.Status;
                model.StartDate = dbobject.StartDate;
            }
            return model;
        }
        private Project MapModelToDbObject(ProjectModel model)
        {
            var dbobject = new Project();
            if (model != null)
            {
                dbobject.ProjectId = model.ProjectId;
                dbobject.Title = model.Title;
                dbobject.Description = model.Description;
                dbobject.Status = model.Status;
                dbobject.StartDate = model.StartDate;
            }
            return dbobject;
        }
        public List<ProjectModel> GetAllProjects()
        {
            var list = new List<ProjectModel>();
            foreach (var dbobject in _DBContext.Projects)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }
            return list;
        }

        public ProjectModel GetProjectById(Guid id)
        {
            return MapDBobjectToModel(_DBContext.Projects.FirstOrDefault(x => x.ProjectId == id));
        }

        public void InsertProject(ProjectModel model)
        {
            model.ProjectId = Guid.NewGuid();
            _DBContext.Projects.Add(MapModelToDbObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateProject(ProjectModel model)
        {
            var dbobject = _DBContext.Projects.FirstOrDefault(x => x.ProjectId == model.ProjectId);
            if (dbobject != null)
            {
                dbobject.ProjectId = model.ProjectId;
                dbobject.Title = model.Title;
                dbobject.Description = model.Description;
                dbobject.Status = model.Status;
                dbobject.StartDate = model.StartDate;
                _DBContext.SaveChanges();
            }
        }

        //public void DeleteProject(Guid id)
        //{
        //    var project = _DBContext.Projects.FirstOrDefault(x => x.ProjectId == id);

        //    if (project != null)
        //    {
        //        var tasks = _DBContext.ProjectTasks.Where(x => x.ProjectId == id);
        //        foreach (var task in tasks)
        //        {
        //            _DBContext.ProjectTasks.Remove(task);
        //        }
        //        _DBContext.Projects.Remove(project);
        //        _DBContext.SaveChanges();
        //    }


        //public void DeleteTask(Guid id)
        //{
        //    var dbobject = _DBContext.ProjectTasks.FirstOrDefault(x => x.TaskId == id);
        //    if (dbobject != null)
        //    {
        //        var comments = _DBContext.Comments.Where(x => x.TaskId == id);
        //        if (comments != null)
        //        {
        //            foreach (var comment in comments)
        //            {
        //                _DBContext.Comments.Remove(comment);
        //            }
        //        }

        //        _DBContext.ProjectTasks.Remove(dbobject);
        //        _DBContext.SaveChanges();
        //    }

            public void DeleteProject(Guid id)
        {
            var project = _DBContext.Projects.FirstOrDefault(x => x.ProjectId == id);
            if (project != null)
            {
                var tasks = _DBContext.ProjectTasks.Where(x => x.ProjectId == id);
                foreach(var task in tasks)
                {
                    var comments = _DBContext.Comments.Where(x => x.TaskId == task.TaskId);
                    if (comments != null)
                     {
                        foreach (var comment in comments)
                        {
                            _DBContext.Comments.Remove(comment);
                        }
                           
                    }
                    _DBContext.ProjectTasks.Remove(task);
                }
                _DBContext.Projects.Remove(project);
                _DBContext.SaveChanges();
            }
        }
    }
}
