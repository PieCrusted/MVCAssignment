using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities {
    public class Reviews {
        public int Id { get; set; } 
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
    }
}