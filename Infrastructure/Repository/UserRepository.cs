using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class UserRepository : BaseRepository<ApplicationCore.Entities.User>, IUserRepository {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}