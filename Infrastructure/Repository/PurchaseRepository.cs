using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository {
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository {
        public PurchaseRepository(DbContext dbContext) : base(dbContext) { }
    }
}