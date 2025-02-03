using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services {
    public interface IMovieService {
        Task<IEnumerable<MovieCardModel>> GetTop30HighestGrossingMovies();
        Task<MovieCardModel> GetMovieDetails(int movieId);
    }
}