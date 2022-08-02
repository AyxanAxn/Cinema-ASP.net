using System.ComponentModel.DataAnnotations;

namespace Cinema.Models.DTOs
{
    public class RoomDTO
    { 
        [Required]
        public int RoomNumber { get; set; }
    }
}
