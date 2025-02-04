using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services {
    public interface IMovieService {
        Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies();
        Task<Movie> GetMovieDetails(int movieId);
    }
}