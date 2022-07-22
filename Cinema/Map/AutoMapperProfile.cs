using AutoMapper;
using Cinema.Models;
using Cinema.Models.DTOs;

namespace Cinema.Map
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoomViewModel, Room>().ReverseMap();
        }
    }
}
