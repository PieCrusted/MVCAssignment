using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class ReportRepository : BaseRepository<ApplicationCore.Entities.Report>, IReportRepository {
        public ReportRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}