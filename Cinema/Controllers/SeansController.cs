using Cinema.Models;
using Cinema.UnitOfWorks.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class SeansController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeansController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("AddSeans")]
        public IActionResult AddSeans(Seans seans)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Seans.Add(seans);
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
