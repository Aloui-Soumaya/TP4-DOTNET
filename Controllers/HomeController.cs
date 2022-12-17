using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics;
using TP4_Soumaya.Data;
using TP4_Soumaya.Models;

namespace TP4_Soumaya.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            Debug.WriteLine("********* Ici on a instantié pour la permière fois *********");
            UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            Debug.WriteLine("le nombre d'inctance de la classe universityContext est : " + UniversityContext.nb_instance);
            List<Student> s = universityContext.Student.ToList();
            foreach (Student student in s)
            {
                Debug.WriteLine("Etudiant  avec : *Id : "+student.id+ " *Nom : " +student.first_name + student.last_name+ "*numero det telephone : "+student.phone_number);
            }
            return View();
        }

        public IActionResult Privacy(string id)
        {
            Debug.WriteLine("********* Ici on a instantié pour la deuxiéme fois *********");
            UniversityContext dbContext = UniversityContext.Instantiate_UniversityContext();
            Debug.WriteLine("le nombre d'inctance de la classe universityContext est : " + UniversityContext.nb_instance);
            ViewBag.Message = "Your application description page.";
            // le nombre d'instance = 1 !!!

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}