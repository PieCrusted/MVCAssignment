using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

namespace Infrastructure.Repository {
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository {
        private readonly MovieShopDbContext _dbContext;
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }
        public async Task<List<Movie>> GetMoviesByGenre(int genreId, int pageSize = 30, int page = 1) {
            return await _dbContext.MovieGenres
                .Where(mg => mg.GenreId == genreId)
                .Select(mg => mg.MovieId)
                .Join(_dbContext.Movies, movieId => movieId, m => m.Id, (movieId, movie) => movie)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}