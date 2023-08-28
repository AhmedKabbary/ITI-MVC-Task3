using Microsoft.EntityFrameworkCore;

using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IDepartmentService
    {
        public IEnumerable<Department> Index();

        public Department? Details(int id);

        public void Create(Department department);

        public void Edit(Department department);

        public void Delete(Department department);
    }
}