using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository {
    public class GenreRepository : BaseRepository<ApplicationCore.Entities.Genre>, IGenreRepository {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}