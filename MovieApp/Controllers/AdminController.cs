using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers {
    public class AdminController : Controller {
         public IActionResult Index() {
            return View();
        }
    }
}