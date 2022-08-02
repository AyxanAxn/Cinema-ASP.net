namespace Cinema.Models.DTOs
{
    public class MovieDTO
    {
        public string Genre { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public List<int> ActorId { get; set; }
    }
}
