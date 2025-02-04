using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities {
    public class Favorites {
        public int Id { get; set; } 
        public int MovieId { get; set; }
        public int UserId { get; set; }
    }
}