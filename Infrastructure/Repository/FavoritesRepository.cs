using ApplicationCore.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repository {
    public class FavoritesRepository : BaseRepository<ApplicationCore.Entities.Favorites>, IFavoritesRepository {
        public FavoritesRepository(MovieShopDbContext dbContext) : base(dbContext) { }
    }
}