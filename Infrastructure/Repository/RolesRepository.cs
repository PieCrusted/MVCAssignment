using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class RolesRepository : BaseRepository<ApplicationCore.Entities.Roles>, IRolesRepository {
        public RolesRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}