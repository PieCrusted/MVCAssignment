using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository {
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository {
        public MovieRepository(DbContext dbContext) : base(dbContext) { }
    }
}