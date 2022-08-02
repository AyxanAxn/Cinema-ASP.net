using Cinema.EntityBases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cinema.Models
{
    public class Seans
    {
        public int Id { get; set; } 
        public int MovieId { get; set; }
        public double Price { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public Movie Movie { get; set; }
        public List<Room> Rooms { get; set; }
        public List<SeansReserves> SeansReserves { get; set; }
    }
}
