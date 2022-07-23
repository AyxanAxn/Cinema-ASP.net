using AutoMapper;
using Cinema.Models;
using Cinema.Models.DTOs;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class SeansController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SeansController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("AddSeans")]
        public IActionResult AddSeans(SeansDTO seansDTO)
        {
            if (ModelState.IsValid)
            {
                List<Room> currentRooms = new List<Room>();
                var currentMovie = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == seansDTO.MovieId);
                if (currentMovie == null) return NotFound("Movie not found");
                var mappedSeans = _mapper.Map<Seans>(seansDTO);
                mappedSeans.MovieId= currentMovie.Id;
                mappedSeans.Movie = currentMovie;
                foreach (var roomId in seansDTO.RoomIds)
                {
                    var rooms = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == roomId);
                    if (rooms != null)
                    {
                        currentRooms.Add(rooms);
                    }
                }
                mappedSeans.Rooms = currentRooms;
                _unitOfWork.Seans.Add(mappedSeans);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("RemoveSeans")]
        public IActionResult RemoveSeans(int id)
        {
            if (id != 0)
            {
                var excistingSeans = _unitOfWork.Seans.GetFirstOrDefault(s => s.Id == id);
                if (excistingSeans != null)
                {
                    _unitOfWork.Seans.Remove(excistingSeans);
                    _unitOfWork.Save();
                    return Ok();
                }
            }
            return BadRequest();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
