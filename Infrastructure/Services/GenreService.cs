using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services {
    public class GenreService : IGenreService {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository) {
            _genreRepository = genreRepository;
        }

        public async Task<List<Genre>> GetAllGenres() {
            return (List<Genre>)await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetGenreById(int id) {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateGenre(string name) {
            var genre = new Genre { Name = name };
            await _genreRepository.AddAsync(genre);
            return true;
        }

        public async Task<bool> UpdateGenre(int id, string name) {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return false;
            genre.Name = name;
            await _genreRepository.UpdateAsync(genre);
            return true;
        }

        public async Task<bool> DeleteGenre(int id) {
            await _genreRepository.DeleteAsync(id);
            return true;
        }
    }
}