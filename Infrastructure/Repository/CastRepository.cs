using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class CastRepository : BaseRepository<ApplicationCore.Entities.Cast>, ICastRepository {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}