namespace Cinema.Models.DTOs
{
    public class SeansDTO
    {
        public int MovieId { get; set; }
        public double Price { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public List<int> RoomIds{ get; set; }
    }
}