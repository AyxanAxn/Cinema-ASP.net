using AutoMapper;
using Cinema.Models;
using Cinema.Models.DTOs;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReserveController(IUnitOfWork unitOfWork, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }

        [HttpPost]
        [Route("AddReserve")]
        public async Task<IActionResult> AddReserve(ReserveDTO reserveDTO)
        {
            if (ModelState.IsValid)
            {
                List<Chair> chairs = new List<Chair>();
                List<int> fullChairs = new List<int>();
                List<int> nullChairs = new List<int>();
                var currentRoom = _unitOfWork.Room.GetFirstOrDefault(r => r.Id == reserveDTO.RoomID);
                var currentSeans = _unitOfWork.Seans.GetFirstOrDefault(s => s.Id == reserveDTO.SeansID);
                var currentUser = await _userManager.FindByIdAsync(reserveDTO.UserId);

                if (currentUser == null)
                    return NotFound("User not found");

                if (currentSeans == null)
                    return NotFound("Section not found");

                if (currentRoom == null)
                    return NotFound("Room not found");

                foreach (var chairId in reserveDTO.ChairIds)
                {
                    var reserveChairs = _unitOfWork.Chair.GetFirstOrDefault(c => c.Id == chairId);
                    if (reserveChairs != null)
                    {
                        if (reserveChairs.IsEmpty) chairs.Add(reserveChairs);
                        else fullChairs.Add(reserveChairs.Id);
                    }
                    else nullChairs.Add(chairId);

                }
                if (nullChairs.Count > 0)
                {
                    string message = "";
                    foreach (var item in nullChairs)
                    {
                        message += $"{item} ";
                    }
                    message += "chairs are not found";
                    return NotFound(message);
                }
                if (fullChairs.Count > 0)
                {
                    string message = "";
                    foreach (var item in fullChairs)
                    {
                        message += $"{item} ";
                    }
                    message += "chairs are alredy reserved";
                    return BadRequest(message);
                }

                var mappedReserve = _mapper.Map<Reserve>(reserveDTO);
                mappedReserve.Chairs = chairs;
                mappedReserve.UserId = currentUser.Id;
                mappedReserve.User = (User)currentUser;
                _unitOfWork.Reserve.Add(mappedReserve);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }
    }
}