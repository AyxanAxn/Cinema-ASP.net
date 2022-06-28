namespace Cinema.Models
{
    public class Chair
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public bool IsEmpty { get; set; } = true;
    }
}
