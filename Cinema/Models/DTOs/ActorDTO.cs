namespace Cinema.Models.DTOs
{
    public class ActorDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Movie Movie { get; set; }
    }
}