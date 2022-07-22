using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int Id)
        {
            var movie = _unitOfWork.Movie.GetFirstOrDefault(m => m.Id == Id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Movie.Add(movie);
                _unitOfWork.Save();
                return Ok(movie);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Movie.Update(movie);
                _unitOfWork.Save();
                return Ok(movie);
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var obj = _unitOfWork.Movie.GetFirstOrDefault(c => c.Id == movie.Id);
                if (obj == null) return NotFound();
                _unitOfWork.Movie.Remove(movie);
                _unitOfWork.Save();
                return Ok();
            }
            return BadRequest();
        }
    }
}
