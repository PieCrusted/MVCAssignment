using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers {
    public class UserController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}