using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services {
    public class MovieService : IMovieService {
        public async Task<IEnumerable<MovieCardModel>> GetTop30HighestGrossingMovies() {
            var movies = new List<MovieCardModel> {
                new MovieCardModel { Id = 1, Title = "Movie 1", PosterUrl = "image1.jpg" },
                new MovieCardModel { Id = 2, Title = "Movie 2", PosterUrl = "image2.jpg" },
                new MovieCardModel { Id = 3, Title = "Movie 3", PosterUrl = "image3.jpg" },
                new MovieCardModel { Id = 4, Title = "Movie 4", PosterUrl = "image4.jpg" },
                new MovieCardModel { Id = 5, Title = "Movie 5", PosterUrl = "image5.jpg" }
            };
            return await Task.FromResult(movies);
        }
        public async Task<MovieCardModel> GetMovieDetails(int movieId) {
            return await Task.FromResult(new MovieCardModel { Id = movieId, Title = $"Movie {movieId}", PosterUrl = $"image{movieId}.jpg" });
        }
    }
}