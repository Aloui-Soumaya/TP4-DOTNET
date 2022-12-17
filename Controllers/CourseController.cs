
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP4_Soumaya.Data;
using TP4_Soumaya.Models;

namespace TP4_Soumaya.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {


            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            /*foreach (String courses in studentRepository.GetCourses())
              {
                Debug.WriteLine(courses);
             }
            */
            return View(studentRepository.GetCourses());
        }

        public IActionResult GetCourse(string id)
        {
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            StudentRepository studentRepository = new StudentRepository(universityContext);
            IEnumerable<Student> res = (IEnumerable<Student>)studentRepository.Find(etudcours => etudcours.course.ToLower() == id.ToLower());
            if (res.Count() != 0) ViewBag.Id = res.First().course;
            return View(res);
        }
    }
}
