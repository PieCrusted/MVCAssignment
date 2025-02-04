using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities {
    public class MovieCasts {
        public int Id { get; set; } 
        public int CastId { get; set; }
        public string Character { get; set; }
        public int MovieId { get; set; }
    }
}