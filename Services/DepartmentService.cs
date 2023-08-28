using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ItiContext _dbContext;

        public DepartmentService()
        {
            this._dbContext = new ItiContext();
        }

        public IEnumerable<Department> Index()
        {
            return _dbContext.Departments.ToList();
        }

        public Department? Details(int id)
        {
            return _dbContext.Departments.FirstOrDefault(s => s.Id == id);
        }

        public void Create(Department department)
        {
            _dbContext.Add(department);
            _dbContext.SaveChanges();
        }

        public void Edit(Department department)
        {
            _dbContext.Update(department);
            _dbContext.SaveChanges();
        }

        public void Delete(Department department)
        {
            _dbContext.Remove(department);
            _dbContext.SaveChanges();
        }
    }
}