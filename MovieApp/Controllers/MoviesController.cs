using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using System.Linq;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Models;

namespace MovieApp.Controllers {
    public class MoviesController : Controller {
        private readonly ILogger<MoviesController> _logger;
        private readonly IGenreService _genreService;
        private readonly IGenreRepository _genreRepository;

        public MoviesController(ILogger<MoviesController> logger, IGenreService genreService, IGenreRepository genreRepository) {
            _logger = logger;
            _genreService = genreService;
            _genreRepository = genreRepository;
        }

        public IActionResult Index() {
            return View();
        }
        public async Task<IActionResult> Genre(int genreId, int pageSize = 30, int page = 1) {
            var movies = await _genreService.GetMoviesByGenre(genreId, pageSize, page);
            var genre = await _genreService.GetGenreById(genreId);
            var totalMovies = (await _genreRepository.GetMoviesByGenre(genreId)).Count();
            var model = new MoviesByGenreModel {
                GenreId = genreId,
                PageSize = pageSize,
                Page = page,
                TotalCount = totalMovies,
                Movies = movies
            };
            ViewBag.Genre = genre.Name;
            return View("Index", model);
        }
    }
}