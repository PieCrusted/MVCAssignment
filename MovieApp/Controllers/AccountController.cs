using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers {
    public class AccountController : Controller {
        public IActionResult Index() {
            return View();
        }
        public IActionResult Login() {
            return View();
        }

        public IActionResult Register() {
            return View();
        }
    }
}