using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class UserRolesRepository : BaseRepository<ApplicationCore.Entities.UserRoles>, IUserRolesRepository {
        public UserRolesRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}