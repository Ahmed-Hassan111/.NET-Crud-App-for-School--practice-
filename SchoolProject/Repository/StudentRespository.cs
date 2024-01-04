using DemoEFApp.Context;
using DemoEFApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Respository
{
    public class StudentRespository : IStudentRespository
    {

        private readonly MyContext _MyConnetion;

        public StudentRespository(MyContext myContext)
        {
            _MyConnetion = myContext;
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdsObj in _MyConnetion.Students
                                          select stdsObj).ToList();
                return students;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public void Create(Student student)
        {
            _MyConnetion.Students?.Add(student);
            _MyConnetion.SaveChanges();

        }

        public async Task DeleteAsync(int id)
        {
            Student student = await _MyConnetion.Students.FirstOrDefaultAsync(stdObj => stdObj.StudentId == id);
           
            if (student != null)
            {
                _MyConnetion.Students.Remove(student);
                await _MyConnetion.SaveChangesAsync();
            }
        }


        public void Register(int studentId, int courseId)
        {
            _MyConnetion.StudentCourses?.Add(new StudentCourse
            {
                CourseId = courseId,
                StudentId = studentId
            });
            _MyConnetion.SaveChanges();
        }
    }
}
