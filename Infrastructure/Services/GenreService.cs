using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Services {
    public class GenreService : IGenreService {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _movieRepository;

        public GenreService(IGenreRepository genreRepository, IMovieRepository movieRepository) {
            _genreRepository = genreRepository;
            _movieRepository = movieRepository;
        }

        public async Task<List<Genre>> GetAllGenresAsync() {
            return (List<Genre>)await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id) {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateGenreAsync(string name) {
            var genre = new Genre { Name = name };
            await _genreRepository.AddAsync(genre);
            return true;
        }

        public async Task<bool> UpdateGenreAsync(int id, string name) {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return false;
            genre.Name = name;
            await _genreRepository.UpdateAsync(genre);
            return true;
        }

        public async Task<bool> DeleteGenreAsync(int id) {
            await _genreRepository.DeleteAsync(id);
            return true;
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId, int pageSize = 30, int page = 1) {
            return await _genreRepository.GetMoviesByGenreAsync(genreId, pageSize, page);
        }
    }
}