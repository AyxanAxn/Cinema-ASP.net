namespace Cinema.Models.DTOs
{
    public class ChairDTO
    { 
        public int Number { get; set; }
        public int RoomId { get; set; }
        public bool IsEmpty { get; set; } = true;
    }
}
