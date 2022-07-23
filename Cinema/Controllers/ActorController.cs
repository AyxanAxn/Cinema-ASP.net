using AutoMapper;
using Cinema.Models.DTOs;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ActorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("AddActor")]
        public IActionResult AddActor(ActorDTO addActorDTO)
        {
            if (ModelState.IsValid)
            {

            }
            return BadRequest();
        }
    }
}
