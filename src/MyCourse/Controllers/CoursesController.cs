using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Controllers
{
   public class CoursesController : Controller
   {
      public IActionResult Index()
      {
         return Content("Sono Index");
      }

      public IActionResult Detail(string id)
      {
         return Content($"Sono Deatil e ho ricevuto l 'id {id}");
      }

      public IActionResult Search(string titolo)
      {
         return Content($"Hai cercato {titolo}");
      }

   }
}