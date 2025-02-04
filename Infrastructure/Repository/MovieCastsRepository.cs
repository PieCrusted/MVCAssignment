using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class MovieCastsRepository : BaseRepository<ApplicationCore.Entities.MovieCasts>, IMovieCastsRepository {
        public MovieCastsRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}