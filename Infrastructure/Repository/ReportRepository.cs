using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository {
    public class ReportRepository : BaseRepository<Report>, IReportRepository {
        public ReportRepository(DbContext dbContext) : base(dbContext) { }
    }
}