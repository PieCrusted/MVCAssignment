using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data {
    public class MovieShopDbContext : DbContext {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Trailers> Trailers { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<MovieCasts> MovieCasts { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Favorites> Favorites { get; set; }

        // Constraints on dollar/rating etc
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Movie>().Property(m => m.Budget).HasColumnType("decimal(18, 4)");
            modelBuilder.Entity<Movie>().Property(m => m.Price).HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Movie>().Property(m => m.Revenue).HasColumnType("decimal(18, 4)");
            modelBuilder.Entity<Purchase>().Property(p => p.TotalPrice).HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Reviews>().Property(r => r.Rating).HasColumnType("decimal(4, 2)");
        }
    }
}