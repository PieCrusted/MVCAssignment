using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class TrailersRepository : BaseRepository<ApplicationCore.Entities.Trailers>, ITrailersRepository {
        public TrailersRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}