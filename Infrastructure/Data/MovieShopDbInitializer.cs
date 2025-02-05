using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ApplicationCore.Entities;
using System.Threading;
using System.Reflection;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Infrastructure {
    public static class MovieShopDbInitializer {
        private const string ExecutedScriptsFileName = "executed_scripts.txt";

        public static void Seed(IServiceProvider serviceProvider) {
            using (var scope = serviceProvider.CreateScope()) {
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieShopDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<MovieShopDbContext>>();
                int retryCount = 3;
                TimeSpan retryInterval = TimeSpan.FromSeconds(5);

                for (int i = 0; i < retryCount; i++) {
                    try {
                        dbContext.Database.Migrate();
                        break; // Break out of the loop if migration succeeds
                    } catch (Exception ex) {
                        Console.WriteLine($"Database migration failed (Attempt {i + 1}/{retryCount}): {ex.Message}");
                        if (i == retryCount - 1) {
                            throw; // Re-throw the exception if all retries fail
                        }
                        Thread.Sleep(retryInterval); // Wait before retrying
                    }
                }

                var emptyTables = new List<string>();

                if (!dbContext.Genres.Any()) {
                    emptyTables.Add("Genres");
                }

                if (!dbContext.Movies.Any()) {
                    emptyTables.Add("Movies");
                }

                if (!dbContext.MovieGenres.Any()) {
                    emptyTables.Add("MovieGenres");
                }

                if (!dbContext.Casts.Any()) {
                    emptyTables.Add("Casts");
                }

                if (!dbContext.MovieCasts.Any()) {
                    emptyTables.Add("MovieCasts");
                }

                if (!dbContext.Trailers.Any()) {
                    emptyTables.Add("Trailers");
                }

                if (emptyTables.Any()) {
                    logger.LogWarning($"The following tables are empty: {string.Join(", ", emptyTables)}. Please populate them manually using the SQL scripts from the /Scripts folder.");
                }
            }
        }
    }
}