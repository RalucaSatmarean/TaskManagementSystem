using TaskManagementSystem.Data;
using TaskManagementSystem.Models;
using TaskManagementSystem.Models.DBObjects;

namespace TaskManagementSystem.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _DBContext;
        public EmployeeRepository()
        {
            _DBContext = new ApplicationDbContext();
        }

        public EmployeeRepository(ApplicationDbContext dBContext)
        {
            _DBContext = dBContext;
        }

        private EmployeeModel MapDBobjectToModel(Employee dbobject)
        {
            var model = new EmployeeModel();
            if (dbobject != null)
            {
                model.EmployeeId = dbobject.EmployeeId;
                model.Name = dbobject.Name;
                model.JobTitle = dbobject.JobTitle;
                model.Department = dbobject.Department;

            }
            return model;
        }
        private Employee MapModelToDbObject(EmployeeModel model)
        {
            var dbobject = new Employee();
            if (model != null)
            {
                dbobject.EmployeeId = model.EmployeeId;
                dbobject.Name = model.Name;
                dbobject.JobTitle = model.JobTitle;
                dbobject.Department = model.Department;


            }
            return dbobject;
        }
        public List<EmployeeModel> GetAllEmployees()
        {
            var list = new List<EmployeeModel>();
            foreach (var dbobject in _DBContext.Employees)
            {
                list.Add(MapDBobjectToModel(dbobject));
            }
            return list;
        }

        public EmployeeModel GetEmployeeById(Guid? id)
        {
            if (id != null)
            {
               return MapDBobjectToModel(_DBContext.Employees.FirstOrDefault(x => x.EmployeeId == id));
            }
            return new EmployeeModel();
        }

        public void InsertEmployee(EmployeeModel model)
        {
            model.EmployeeId = Guid.NewGuid();
            _DBContext.Employees.Add(MapModelToDbObject(model));
            _DBContext.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel model)
        {
            var dbobject = _DBContext.Employees.FirstOrDefault(x => x.EmployeeId == model.EmployeeId);
            if (dbobject != null)
            {
                dbobject.EmployeeId = model.EmployeeId;
                dbobject.Name = model.Name;
                dbobject.JobTitle = model.JobTitle;
                dbobject.Department = model.Department;
                _DBContext.SaveChanges();
            }
        }

        public void DeleteEmployee(Guid id)
        {
            var dbobject = _DBContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            if (dbobject != null)
            {
                _DBContext.Employees.Remove(dbobject);
                _DBContext.SaveChanges();
            }
        }
    }
}
