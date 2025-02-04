using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieApp.Controllers {
    public class GenreController : Controller {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService) {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            var genres = await _genreService.GetAllGenres();
            return View(genres);
        }
    }
}