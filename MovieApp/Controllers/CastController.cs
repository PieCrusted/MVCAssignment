using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers {
    public class CastController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}