using AutoMapper;
using Cinema.Models;
using Cinema.Models.DTOs;
namespace Cinema.Map
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ChairDTO, Chair>().ReverseMap();  
            CreateMap<RoomDTO, Room>().ReverseMap();
            CreateMap<RoomDTO, Room>().ReverseMap();
            CreateMap<ChairDTO, Chair>().ReverseMap();
            CreateMap<MovieDTO, Movie>().ReverseMap();
            CreateMap<ActorDTO, Actor>().ReverseMap();
            CreateMap<SeansDTO, Seans>().ReverseMap();
        }
    }
}