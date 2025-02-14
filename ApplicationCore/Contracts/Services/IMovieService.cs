using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services {
    public interface IMovieService {
        Task<IEnumerable<Movie>> GetTop30HighestGrossingMoviesAsync();
        Task<Movie> GetMovieDetailsAsync(int movieId);
    }
}