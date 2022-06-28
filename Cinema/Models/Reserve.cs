namespace Cinema.Models
{
    public class Reserve
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<SeansReserves> SeansReserves { get; set; }
        public List<Chair> Chairs { get; set; }

    }
}
