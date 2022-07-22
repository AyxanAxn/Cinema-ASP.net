using Cinema.EntityBases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Cinema.Models
{
    public class Seans
    {
        public int Id { get; set; }
        [Required]
        public List<Room> Rooms { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [NotMapped]
        [IgnoreDataMember]
        public Movie Movie { get; set; }
        [Required]
        public int MovieId { get; set; }
        [IgnoreDataMember]
        public List<SeansReserves> SeansReserves { get; set; }
    }
}
