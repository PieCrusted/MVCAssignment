using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities {
    public class UserRoles {
        public int Id { get; set; } 
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}