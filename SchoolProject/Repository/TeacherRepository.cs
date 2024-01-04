using DemoEFApp.Context;
using DemoEFApp.Models;
using SchoolProject.Respository;

namespace SchoolProject.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyContext _myContext;
        public TeacherRepository(MyContext myContext)
        {
            _myContext = myContext;
        } 
        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = (from teacherObj in _myContext.Teachers
                                      select teacherObj).ToList();
            return teachers;
        }
        public void Create(Teacher teacher)
        {
            _myContext.Teachers?.Add(teacher);
            _myContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher =(from teacherObj in _myContext.Teachers
                              where teacherObj.TeacherId == id  
                              select  teacherObj).FirstOrDefault();
            _myContext.Teachers.Remove(teacher);
            _myContext.SaveChanges();
        }

    }
}
