using DemoEFApp.Models;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Models.ViewModels;
using SchoolProject.Repository;
using SchoolProject.Respository;
using System.IO;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRespository _studentRespository;
        private readonly ICourseRepository _courseRepository;
        [Obsolete]
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment ;

        [Obsolete]
        public StudentController(IStudentRespository studentRespository , ICourseRepository courseRepository ,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _studentRespository = studentRespository;
            _courseRepository = courseRepository;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Student>stdlst = _studentRespository.GetAllStudents();
            return View(stdlst);
        }
      
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Create(Student student , IFormFile StudentImage)
        {


            Guid guid = Guid.NewGuid();
            var wwrootpath = _environment.WebRootPath + "/StudentImg/";

            if (StudentImage != null)
            {

                string fullpath = System.IO.Path.Combine(wwrootpath , guid + StudentImage.FileName);

            using(var filestream = new FileStream(fullpath, FileMode.Create)){

                StudentImage.CopyTo(filestream);
            };
            student.ImgName = guid + StudentImage.FileName;

            }
            else
            {
                return BadRequest("Please Upload Your photo");
            }


            _studentRespository.Create(student);
            List<Student> stdlst = _studentRespository.GetAllStudents();
            return View("Index", stdlst);
        }
     
        public async Task<IActionResult> Delete(int StudentId)
        {
            if (StudentId > 0)
            {

                await _studentRespository.DeleteAsync(StudentId);
            }
            List<Student> stdlst = _studentRespository.GetAllStudents();
            return View("Index",stdlst);
        }
        [HttpGet]
        public IActionResult Register() 
        {
            StudentCourseVM data = new StudentCourseVM();
            data.Courses = _courseRepository.GetAllCourses();
            data.Students = _studentRespository.GetAllStudents();
            return View(data);
        }
        [HttpPost]
        public IActionResult Register(int StudentId , int CourseId)
        {
            _studentRespository.Register(StudentId, CourseId);
            return RedirectToAction("Register");
        }


    }
}
