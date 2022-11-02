using TaskManagementSystem.Data;
using TaskManagementSystem.Models.DBObjects;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repository
{
    public class UserProfileRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public UserProfileRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public UserProfileRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private UserProfileModel MapDBobjectToModel(UserProfile dbobject)
        {
            var model = new UserProfileModel();
            if (dbobject != null)
            {
                model.UserId = dbobject.UserId;
                model.Name = dbobject.Name;
                model.JobTitle = dbobject.JobTitle;
                
            }
            return model;
        }
        private UserProfile MapModelToDbObject(UserProfileModel model)
        {
            var dbobject = new UserProfile();
            if (model != null)
            {
                dbobject.UserId = model.UserId;
                dbobject.Name = model.Name;
                dbobject.JobTitle = model.JobTitle;
                
            }
            return dbobject;
        }
        public List<UserProfileModel> GetAllUserProfiles()
        {
            var list = new List<UserProfileModel>();
            foreach (var dbobject in _DBContext.UserProfiles)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }
            return list;
        }

        public UserProfileModel GetUserProfileById(Guid id)
        {
            return MapDBobjectToModel(_DBContext.UserProfiles.FirstOrDefault(x => x.UserId == id));
        }

        public void InsertUserProfile(UserProfileModel model)
        {
            model.UserId = Guid.NewGuid();
            _DBContext.UserProfiles.Add(MapModelToDbObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateUserProfile(UserProfileModel model)
        {
            var dbobject = _DBContext.UserProfiles.FirstOrDefault(x => x.UserId == model.UserId);
            if (dbobject != null)
            {
                dbobject.UserId = model.UserId;
                dbobject.Name = model.Name;
                dbobject.JobTitle = model.JobTitle;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteUserProfile(Guid id)
        {
            var dbobject = _DBContext.UserProfiles.FirstOrDefault(x => x.UserId == id);
            if (dbobject != null)
            {
                _DBContext.UserProfiles.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}

