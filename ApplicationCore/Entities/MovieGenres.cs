using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities {
    public class MovieGenres {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int MovieId { get; set; }
    }
}