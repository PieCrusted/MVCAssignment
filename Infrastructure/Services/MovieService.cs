using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Repository;

namespace Infrastructure.Services {
    public class MovieService : IMovieService {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository) {
            _movieRepository = movieRepository;
        }
        public async Task<IEnumerable<MovieCardModel>> GetTop30HighestGrossingMovies() {
            var movies = await _movieRepository.GetAllAsync();
            var movieCards = movies.Select(m => new MovieCardModel {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl
            });
            return movieCards;
        }
        public async Task<MovieCardModel> GetMovieDetails(int movieId) {
            var movie = await _movieRepository.GetByIdAsync(movieId);
            var movieCard = new MovieCardModel {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl
            };
            return movieCard;
        }
    }
}