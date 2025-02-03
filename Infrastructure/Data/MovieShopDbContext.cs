using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class MovieShopDbContext : DbContext {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}