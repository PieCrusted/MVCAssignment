// using Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using System;
// using System.Linq;
// using ApplicationCore.Entities;
// using System.Threading;
//
// namespace Infrastructure {
//     public static class MovieShopDbInitializer {
//         public static void Seed(IServiceProvider serviceProvider) {
//             var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
//             using (var scope = scopeFactory.CreateScope()) {
//                 var dbContext = scope.ServiceProvider.GetRequiredService<MovieShopDbContext>();
//                 int retryCount = 3;
//                 TimeSpan retryInterval = TimeSpan.FromSeconds(5);
//
//                 for (int i = 0; i < retryCount; i++) {
//                     try {
//                         dbContext.Database.Migrate();
//                         break; // Break out of the loop if migration succeeds
//                     } catch (Exception ex) {
//                         Console.WriteLine($"Database migration failed (Attempt {i + 1}/{retryCount}): {ex.Message}");
//                         if (i == retryCount - 1) {
//                             throw; // Re-throw the exception if all retries fail
//                         }
//                         Thread.Sleep(retryInterval); // Wait before retrying
//                     }
//                 }
//////////////////////////////////////////////////////////
// Swap with top version if stable and we don't need detailed error messages
//////////////////////////////////////////////////////////
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ApplicationCore.Entities;

namespace Infrastructure {
    public static class MovieShopDbInitializer {
        public static void Seed(IServiceProvider serviceProvider) {
            using (var scope = serviceProvider.CreateScope()) {
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieShopDbContext>();
                try {
                    dbContext.Database.Migrate();
                } catch (Exception) {
                    // If database is not available, it will throw exception.
                    Console.WriteLine("Database is not available.");
                }
                if (dbContext.Genres.Any()) {
                    // DB has been seeded
                    return;
                }

                dbContext.Genres.AddRange(
                    new Genre { Name = "Action" },
                    new Genre { Name = "Comedy" },
                    new Genre { Name = "Drama" },
                    new Genre { Name = "Fantasy" },
                    new Genre { Name = "Horror" },
                    new Genre { Name = "Mystery" },
                    new Genre { Name = "Romance" },
                    new Genre { Name = "Thriller" },
                    new Genre { Name = "Western" },
                    new Genre { Name = "Eastern" },
                    new Genre { Name = "Western" }
                );

                dbContext.Movies.AddRange(
                    new Movie { Title = "Sousou no Frieren", PosterUrl = "https://u.livechart.me/anime/11376/poster_image/c7df8b9d73b2b0884572cb3ae2059def.webp/large.jpg" },
                    new Movie { Title = "One Piece", PosterUrl = "https://u.livechart.me/anime/321/poster_image/b121b16f4061e35e27b6d758b2e9503a.jpg/large.jpg" },
                    new Movie { Title = "Koe no Katachi", PosterUrl = "https://u.livechart.me/anime/1296/poster_image/e25da494ba4ddcf86758dbf05db9cfea.webp/large.jpg" },
                    new Movie { Title = "Steins;Gate", PosterUrl = "https://u.livechart.me/anime/1554/poster_image/721563bd590b779bed8ed69e8eea0511.png/large.jpg" },
                    new Movie { Title = "Kimi no Na wa.", PosterUrl = "https://u.livechart.me/anime/3558/poster_image/c29afaa349001436c56feac1d18b3530.png/large.jpg" }
                );

                dbContext.SaveChanges();
            }
        }
    }
}