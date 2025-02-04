using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class MovieGenresRepository : BaseRepository<ApplicationCore.Entities.MovieGenres>, IMovieGenresRepository {
        public MovieGenresRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}