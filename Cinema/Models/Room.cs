using Cinema.EntityBases;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Room
    {
        public int Id { get; set ; }
        public int RoomNumber { get; set; }
        public List<Chair> NumberOfChairs { get; set; }
    }
}
