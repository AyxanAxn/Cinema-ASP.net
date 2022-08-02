using AutoMapper;
using Cinema.Models;
using Cinema.Models.DTOs;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MoviesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(MovieDTO addMovieDTO)
        {
            if (ModelState.IsValid)
            {
                List<Actor> actors = new List<Actor>();
                foreach (var actor in addMovieDTO.ActorId)
                {
                    var actorsInMovie = _unitOfWork.Actor.GetFirstOrDefault(a => a.Id == actor);
                    if (actorsInMovie == null)
                        return NotFound();
                    actors.Add(actorsInMovie);
                }
                var mappedMovie = _mapper.Map<Movie>(addMovieDTO);
                mappedMovie.Actors = actors;
                _unitOfWork.Movie.Add(mappedMovie);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var obj = _unitOfWork.Movie.GetFirstOrDefault(c => c.Id == id);
                if (obj == null) return NotFound();
                _unitOfWork.Movie.Remove(obj);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }
    }
}
