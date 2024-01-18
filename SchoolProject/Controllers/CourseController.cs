using DemoEFApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Repository;
using SchoolProject.Respository;

namespace SchoolProject.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ITeacherRepository _teacherRepository;
        public CourseController(ICourseRepository courseRepository , ITeacherRepository teacherRepository)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return View(courses);
        }
        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            if (course != null)
            {
                _courseRepository.Create(course);
            }
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index",courses);
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                _courseRepository.Delete(id);
            }
            List<Course> courses = _courseRepository.GetAllCourses();
            return View("Index", courses);
        }
    }
}
