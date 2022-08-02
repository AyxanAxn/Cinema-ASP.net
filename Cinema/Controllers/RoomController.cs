using AutoMapper;
using Cinema.DB;
using Cinema.Models;
using Cinema.Models.DTOs;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace Cinema.Controllers
{
    [EnableCors("*","*","*")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoomController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("AddChair")]
        public IActionResult AddChair(ChairDTO AddChair)
        {
            if (AddChair != null)
            {
                var mappedChair = _mapper.Map<Chair>(AddChair);
                var currentRoom = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == AddChair.RoomId);
                if (currentRoom != null)
                {
                    mappedChair.Room = currentRoom;
                    _unitOfWork.Chair.Add(mappedChair);
                    _unitOfWork.Save();
                    return Ok();
                }
                return NotFound();

            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("RemoveChair")]
        public IActionResult RemoveChair(List<int> ChairIds)
        {
            if (ChairIds != null)
            {
                List<Chair> existingChairs = new List<Chair>();
                foreach (var item in ChairIds)
                {
                    var chair = _unitOfWork.Chair.GetFirstOrDefault(c => c.Id == item);
                    if (chair != null)
                    {
                        existingChairs.Add(chair);
                    }
                }
                for (int i = 0; i < existingChairs.Count; i++)
                {
                    _unitOfWork.Chair.Remove(existingChairs[i]);
                }
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("AddRoom")]
        public IActionResult AddRoom(RoomDTO AddRoom)
        {
            if (!_unitOfWork.Room.GetAll().Any(r => r.RoomNumber == AddRoom.RoomNumber))
            {
                var mappedRoom = _mapper.Map<Room>(AddRoom);
                _unitOfWork.Room.Add(mappedRoom);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("RemoveRoom")]
        public IActionResult RemoveRoom(int id)
        {
            if (id != 0)
            {
                var SelectedRoom = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == id);
                if (SelectedRoom != null)
                {
                    _unitOfWork.Room.Remove(SelectedRoom);
                    _unitOfWork.Save();
                    return Ok();
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetRooms")]
        public IActionResult GetRooms() {
            var roomDatas = _unitOfWork.Room.GetAll();
            if (roomDatas.ToList().Count > 0)
            {
                return Ok(roomDatas);
            }
            return BadRequest(); 
        
        }
    }
}