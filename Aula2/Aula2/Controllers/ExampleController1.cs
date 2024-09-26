using Microsoft.AspNetCore.Mvc;

namespace Aula2.Controllers
{
    public class ExampleController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formData)
        {
            ViewData["text_inserted"] = formData["name"];
            ViewData["other_text_inserted"] = formData["age"];

            return View("Index2");
        }

    }

}