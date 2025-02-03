using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository {
    public class UserRepository : BaseRepository<User>, IUserRepository {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}