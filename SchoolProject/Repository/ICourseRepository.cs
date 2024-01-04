using DemoEFApp.Models;

namespace SchoolProject.Repository
{
    public interface ICourseRepository
    {
        public List<Course> GetAllCourses();
        public void Create(Course course);
        public void Delete(int id);
    }
}
