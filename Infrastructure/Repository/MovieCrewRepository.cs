using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class MovieCrewRepository : BaseRepository<ApplicationCore.Entities.MovieCrew>, IMovieCrewRepository {
        public MovieCrewRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}