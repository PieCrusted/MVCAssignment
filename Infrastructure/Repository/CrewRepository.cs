using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class CrewRepository : BaseRepository<ApplicationCore.Entities.Crew>, ICrewRepository {
        public CrewRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}