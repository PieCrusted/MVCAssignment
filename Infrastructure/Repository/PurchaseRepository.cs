using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class PurchaseRepository : BaseRepository<ApplicationCore.Entities.Purchase>, IPurchaseRepository {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}