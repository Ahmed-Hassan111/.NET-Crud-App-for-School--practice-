using DemoEFApp.Models;

namespace SchoolProject.Respository
{
    public interface IStudentRespository
    {
        public List<Student> GetAllStudents();
        public void Create(Student student);
        Task DeleteAsync(int id);
        public void Register(int studentId, int courseId);

    }
}
