using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
   public class CoursesController : Controller
   {
      public IActionResult Index()
      {
         return View();
      }

      public IActionResult Detail(string id)
      {
         return View();
      }

      public IActionResult Search(string titolo)
      {
         return Content($"Hai cercato {titolo}");
      }

   }
}