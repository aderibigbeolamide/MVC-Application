using Microsoft.AspNetCore.Mvc;
using MVCVottingApp.Data;
using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

namespace MVCVottingApp.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IPositionRepository _positionRepository;

        public PositionController(MVCVottingAppContext mVCVottingAppContext)
        {
            _positionRepository = new PositionRepository(mVCVottingAppContext);
            _positionService = new PositionService(_positionRepository);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePosition() => View(new CreatePositionRequestModel());

        [HttpPost]
        public async Task<IActionResult> CreatePosition(CreatePositionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var position = await _positionService.CreatePositionAsync(model);
            if (position.Success == false)
            {
                ViewBag.Message = position.Message;
                return View(model);
            }
            ViewBag.Message = position.Message;
            return RedirectToAction("Index", "Position");
        }
    }
}