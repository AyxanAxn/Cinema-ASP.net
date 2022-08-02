namespace Cinema.Models.DTOs
{
    public class ReserveDTO
    {
        public int RoomID { get; set; }
        public string UserId { get; set; }
        public int SeansID { get; set; }
        public List<int> ChairIds { get; set; }
    }
}