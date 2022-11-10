using Microsoft.AspNetCore.Mvc;
using MVCVottingApp.Data;
using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

namespace MVCVottingApp.Controllers
{
    public class ContestantController : Controller
    {
        private readonly IContestantService _contestantService;
        private readonly IContestantRepository _contestantRepository;

        public ContestantController(MVCVottingAppContext mVCVottingAppContext)
        {
            _contestantRepository = new ContestantRepository(mVCVottingAppContext);
            _contestantService = new ContestantService(_contestantRepository);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateContestant() => View(new CreateContestRequestModel());

        [HttpPost]
        public async Task<IActionResult> CreateContestant(CreateContestRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var contestant = await _contestantService.CreateContestantAsync(model);
            if (contestant.Success == false)
            {
                ViewBag.Message = contestant.Message;
                return View(model);
            }
            ViewBag.Message = contestant.Message;
            return RedirectToAction("Index", "Contestant");
        }

        [HttpGet]
        public IActionResult GetAllContestants() => View();

        [HttpPost]
        public async Task<IActionResult> GetAllContestants(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var contestant = await _contestantService.GetAllContestantAsync();
            if (contestant.Success == false)
            {
                ViewBag.Message = contestant.Message;
                return View();
            }
            ViewBag.Message = contestant.Message;
            return RedirectToAction("Index", "Contestant");
        }

        [HttpGet]
        public IActionResult CheckContestantVote() => View();

        [HttpPost]
        public async Task<IActionResult> CheckContestantVote(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var contestant = await _contestantService.CheckContestantVoteAsync(id);
            if (contestant.Success == false)
            {
                ViewBag.Message = contestant.Message;
                return View();
            }
            ViewBag.Message = contestant.Message;
            return RedirectToAction("Index", "Contestant");
        }

        [HttpGet]
        public IActionResult Contest() => View();

        [HttpPost]
        public async Task<IActionResult> Contest(int id, decimal grade)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var contestant = await _contestantService.ContestAsyc(id, grade);
            if (contestant.Success == false)
            {
                ViewBag.Message = contestant.Message;
                return View();
            }
            ViewBag.Message = contestant.Message;
            return RedirectToAction("Index", "Contestant");
        }
        
    }
}