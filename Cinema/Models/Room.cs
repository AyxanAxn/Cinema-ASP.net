﻿using Cinema.EntityBases;

namespace Cinema.Models
{
    public class Room : IEntityBases
    {
        public int Id { get; set ; }
        public int RoomNumber { get; set; }
        public List<Chair> NumberOfChairs { get; set; }
    }
}
