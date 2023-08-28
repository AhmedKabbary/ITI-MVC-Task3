using Microsoft.EntityFrameworkCore;

using WebApplication4.Models;

namespace WebApplication4.Services
{
    public class StudentService : IStudentService
    {
        private readonly ItiContext _dbContext;

        public StudentService()
        {
            this._dbContext = new ItiContext();
        }

        public IEnumerable<Student> Index()
        {
            return _dbContext.Students.Include(s => s.Department).ToList();
        }

        public Student? Details(int id)
        {
            return _dbContext.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
        }

        public void Create(Student student)
        {
            _dbContext.Add(student);
            _dbContext.SaveChanges();
        }

        public void Edit(Student student)
        {
            _dbContext.Update(student);
            _dbContext.SaveChanges();
        }

        public void Delete(Student student)
        {
            _dbContext.Remove(student);
            _dbContext.SaveChanges();
        }
    }
}