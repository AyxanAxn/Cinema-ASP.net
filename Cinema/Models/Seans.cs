using Cinema.EntityBases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cinema.Models
{
    public class Seans
    {
        public int Id { get; set; }

        public List<Room> Rooms { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [NotMapped]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public List<SeansReserves> SeansReserves { get; set; }
    }
}
