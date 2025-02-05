using ApplicationCore.Entities;
using System.Collections.Generic;

namespace ApplicationCore.Models {
    public class MoviesByGenreModel {
        public int GenreId { get; set; }
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}