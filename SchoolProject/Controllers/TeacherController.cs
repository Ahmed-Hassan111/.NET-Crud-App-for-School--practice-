using DemoEFApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Respository;

namespace SchoolProject.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if(teacher != null)
            {
            _teacherRepository.Create(teacher); 
            }
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index", teachers);
        }
        public ActionResult Delete(int id) 
        {
            if(id > 0)
            {
            _teacherRepository.Delete(id);  
            }
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();

            return View("Index", teachers);
        }
    }
}
