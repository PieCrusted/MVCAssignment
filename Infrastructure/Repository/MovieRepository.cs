using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class MovieRepository : BaseRepository<ApplicationCore.Entities.Movie>, IMovieRepository {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}