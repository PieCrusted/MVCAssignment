using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services {
    public interface IGenreService {
        Task<List<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task<bool> CreateGenreAsync(string name);
        Task<bool> UpdateGenreAsync(int id, string name);
        Task<bool> DeleteGenreAsync(int id);
        Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize = 30, int page = 1);
    }
}