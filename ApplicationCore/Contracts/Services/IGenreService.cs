using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services {
    public interface IGenreService {
        Task<List<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
        Task<bool> CreateGenre(string name);
        Task<bool> UpdateGenre(int id, string name);
        Task<bool> DeleteGenre(int id);
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int page = 1);
    }
}