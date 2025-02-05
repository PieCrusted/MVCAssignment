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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Movies
            modelBuilder.Entity<Movie>().Property(m => m.BackdropUrl).HasColumnType("nvarchar(2084)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.Budget).HasColumnType("decimal(18, 4)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.CreatedBy).HasColumnType("nvarchar(MAX)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.CreatedDate).HasColumnType("datetime2").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.ImdbUrl).HasColumnType("nvarchar(2084)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.OriginalLanguage).HasColumnType("nvarchar(64)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.Overview).HasColumnType("nvarchar(MAX)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.PosterUrl).HasColumnType("nvarchar(2084)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.Price).HasColumnType("decimal(5, 2)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.Revenue).HasColumnType("decimal(18, 4)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.RunTime).HasColumnType("int").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.Tagline).HasColumnType("nvarchar(512)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.Title).HasColumnType("nvarchar(256)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.TmdbUrl).HasColumnType("nvarchar(2084)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.UpdatedBy).HasColumnType("nvarchar(MAX)").IsRequired(false);
            modelBuilder.Entity<Movie>().Property(m => m.UpdatedDate).HasColumnType("datetime2").IsRequired(false);

            // Genres
            modelBuilder.Entity<Genre>().Property(g => g.Name).HasColumnType("nvarchar(24)");

            // Casts
            modelBuilder.Entity<Cast>().Property(c => c.Gender).HasColumnType("nvarchar(MAX)");
            modelBuilder.Entity<Cast>().Property(c => c.Name).HasColumnType("nvarchar(128)");
            modelBuilder.Entity<Cast>().Property(c => c.ProfilePath).HasColumnType("nvarchar(2084)");
            modelBuilder.Entity<Cast>().Property(c => c.TmdbUrl).HasColumnType("nvarchar(MAX)");

            // Users
            modelBuilder.Entity<User>().Property(u => u.DateOfBirth).HasColumnType("datetime2").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("nvarchar(256)");
            modelBuilder.Entity<User>().Property(u => u.FirstName).HasColumnType("nvarchar(128)");
            modelBuilder.Entity<User>().Property(u => u.HashedPassword).HasColumnType("nvarchar(1024)");
            modelBuilder.Entity<User>().Property(u => u.IsLocked).HasColumnType("bit").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.LastName).HasColumnType("nvarchar(128)");
            modelBuilder.Entity<User>().Property(u => u.PhoneNumber).HasColumnType("nvarchar(16)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.ProfilePictureUrl).HasColumnType("nvarchar(MAX)").IsRequired(false);
            modelBuilder.Entity<User>().Property(u => u.Salt).HasColumnType("nvarchar(1024)");

            // Purchases
            modelBuilder.Entity<Purchase>().Property(p => p.PurchaseDateTime).HasColumnType("datetime2");
            modelBuilder.Entity<Purchase>().Property(p => p.PurchaseNumber).HasColumnType("uniqueidentifier");
            modelBuilder.Entity<Purchase>().Property(p => p.TotalPrice).HasColumnType("decimal(5, 2)");

            // Trailers
            modelBuilder.Entity<Trailers>().Property(t => t.Name).HasColumnType("nvarchar(2084)");
            modelBuilder.Entity<Trailers>().Property(t => t.TrailerUrl).HasColumnType("nvarchar(2084)");

            // Reviews
            modelBuilder.Entity<Reviews>().Property(r => r.CreatedDate).HasColumnType("datetime2");
            modelBuilder.Entity<Reviews>().Property(r => r.Rating).HasColumnType("decimal(3, 2)");
            modelBuilder.Entity<Reviews>().Property(r => r.ReviewText).HasColumnType("nvarchar(MAX)");

            //MovieCasts
            modelBuilder.Entity<MovieCasts>().Property(r => r.Character).HasColumnType("nvarchar(450)");

            // Roles
            modelBuilder.Entity<Roles>().Property(r => r.Name).HasColumnType("nvarchar(20)");
        }
    }
}