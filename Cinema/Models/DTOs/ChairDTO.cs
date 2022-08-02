using System.ComponentModel.DataAnnotations;

namespace Cinema.Models.DTOs
{
    public class ChairDTO
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int RoomId { get; set; }
        public bool IsEmpty { get; set; } = true;
    }
}
