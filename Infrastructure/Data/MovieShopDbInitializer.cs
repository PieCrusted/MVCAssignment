using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using ApplicationCore.Entities;
using System.Threading;
using System.Reflection;
using System.IO;

namespace Infrastructure {
    public static class MovieShopDbInitializer {
        private const string ExecutedScriptsFileName = "executed_scripts.txt";
        public static void Seed(IServiceProvider serviceProvider) {
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope()) {
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieShopDbContext>();
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

                // Execute SQL scripts
                var assembly = Assembly.GetExecutingAssembly();
                var scriptNames = assembly.GetManifestResourceNames();
                var executedScripts = GetExecutedScripts();

                foreach (var scriptName in scriptNames) {
                    if (scriptName.EndsWith(".sql") && !executedScripts.Contains(scriptName)) {
                        using (var stream = assembly.GetManifestResourceStream(scriptName))
                        using (var reader = new StreamReader(stream)) {
                            var sqlScript = reader.ReadToEnd();
                            dbContext.Database.ExecuteSqlRaw(sqlScript);
                            MarkScriptAsExecuted(scriptName);
                        }
                    }
                }
                dbContext.SaveChanges();
            }
        }
        private static string GetExecutedScriptsFilePath() {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(basePath, ExecutedScriptsFileName);
        }
        private static List<string> GetExecutedScripts() {
            var filePath = GetExecutedScriptsFilePath();

            if (!File.Exists(filePath)) {
                return new List<string>();
            }

            return File.ReadAllLines(filePath).ToList();
        }

        private static void MarkScriptAsExecuted(string scriptName) {
            var filePath = GetExecutedScriptsFilePath();
            File.AppendAllText(filePath, scriptName + Environment.NewLine);
        }
    }
}