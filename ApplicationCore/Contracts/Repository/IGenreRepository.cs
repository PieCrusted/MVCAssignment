using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository {
    public interface IGenreRepository : IBaseRepository<Genre> {
        Task<List<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize = 30, int page = 1);
    }
}