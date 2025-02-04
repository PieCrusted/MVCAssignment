using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class ReviewsRepository : BaseRepository<ApplicationCore.Entities.Reviews>, IReviewsRepository {
        public ReviewsRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}