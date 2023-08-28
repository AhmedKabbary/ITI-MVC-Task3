using WebApplication4.Models;

namespace WebApplication4.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> Index();

        Student? Details(int id);

        void Create(Student student);

        void Edit(Student student);

        void Delete(Student student);
    }
}