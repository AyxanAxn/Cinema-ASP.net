namespace Cinema.Models
{
    public class SeansReserves
    {
        public int Id { get; set; }
        public int SeansId { get; set; }
        public Seans Seans { get; set; }
        public int ReserveId { get; set; }
        public Reserve Reserve { get; set; }
    }
}
