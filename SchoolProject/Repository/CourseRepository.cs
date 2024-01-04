using DemoEFApp.Context;
using DemoEFApp.Models;

namespace SchoolProject.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyContext _myContext;
        public CourseRepository(MyContext myContext)
        {
            _myContext = myContext;
        }
        public List<Course> GetAllCourses()
        {
            List<Course> courses = (from courseObj in _myContext.Courses
                                    select courseObj).ToList();
            return courses;
        }
        public void Create(Course course)
        {
            _myContext.Courses?.Add(course);
            _myContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Course course = (from courseObj in _myContext.Courses
                               where courseObj.CourseId == id
                               select courseObj).FirstOrDefault();
            _myContext.Courses.Remove(course);
            _myContext.SaveChanges();
        }

    }
}
