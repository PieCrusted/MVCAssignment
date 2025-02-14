using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieApp.ViewComponents {
    [ViewComponent(Name = "GenresViewComponent")]
    public class GenresViewComponent : ViewComponent {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService) {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var genres = await _genreService.GetAllGenresAsync();
            return View("~/Views/Shared/Components/GenresViewComponent/Default.cshtml", genres);
        }
    }
}