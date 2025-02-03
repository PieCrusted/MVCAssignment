using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services {
    public class MovieService : IMovieService {
        public async Task<IEnumerable<MovieCardModel>> GetTop30HighestGrossingMovies() {
            var movies = new List<MovieCardModel> {
                new MovieCardModel { Id = 1, Title = "Sousou no Frieren", PosterUrl = "https://u.livechart.me/anime/11376/poster_image/c7df8b9d73b2b0884572cb3ae2059def.webp/large.jpg" },
                new MovieCardModel { Id = 2, Title = "One Piece", PosterUrl = "https://u.livechart.me/anime/321/poster_image/b121b16f4061e35e27b6d758b2e9503a.jpg/large.jpg" },
                new MovieCardModel { Id = 3, Title = "Koe no Katachi", PosterUrl = "https://u.livechart.me/anime/1296/poster_image/e25da494ba4ddcf86758dbf05db9cfea.webp/large.jpg" },
                new MovieCardModel { Id = 4, Title = "Steins;Gate", PosterUrl = "https://u.livechart.me/anime/1554/poster_image/721563bd590b779bed8ed69e8eea0511.png/large.jpg" },
                new MovieCardModel { Id = 5, Title = "Kimi no Na wa.", PosterUrl = "https://u.livechart.me/anime/3558/poster_image/c29afaa349001436c56feac1d18b3530.png/large.jpg" }
            };
            return await Task.FromResult(movies);
        }
        public async Task<MovieCardModel> GetMovieDetails(int movieId) {
            return await Task.FromResult(new MovieCardModel { Id = movieId, Title = $"Movie {movieId}", PosterUrl = $"image{movieId}.jpg" });
        }
    }
}