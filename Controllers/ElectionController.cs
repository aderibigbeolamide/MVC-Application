using Microsoft.AspNetCore.Mvc;
using MVCVottingApp.Data;
using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

namespace MVCVottingApp.Controllers
{
    public class ElectionCotroller : Controller
    {
        private readonly IElectionService _electionService;
        private readonly IElectionRepository _electionRepository;

        public ElectionCotroller(MVCVottingAppContext mVCVottingAppContext)
        {
            _electionRepository = new ElectionRepository(mVCVottingAppContext);
            _electionService = new ElectionService(_electionRepository);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateElection() => View(new CreateElectionRequestModel());

        [HttpPost]
        public async Task<IActionResult> CreateElection(CreateElectionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var election = await _electionService.CreateElectionAsync(model);
            if (election.Success == false)
            {
                ViewBag.Message = election.Message;
                return View(model);
            }
            ViewBag.Message = election.Message;
            return RedirectToAction("Index", "Election");
        }

        [HttpGet]
        public IActionResult GetElectionByEndDate() => View();

        [HttpPost]
        public async Task<IActionResult> GetElectionByEndDate(int id, DateTime EndDate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var election = await _electionService.GetElectionByEndDateAsync(id,EndDate);
            if (election.Success == false)
            {
                ViewBag.Message = election.Message;
                return View();
            }
            ViewBag.Message = election.Message;
            return RedirectToAction("Index", "Election");
        }

        [HttpGet]
        public IActionResult GetElectionByStartDate() => View();

        [HttpPost]
        public async Task<IActionResult> GetElectionByStartDate(int id, DateTime StartDate)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var election = await _electionService.GetElectionByStartDateAsync(id, StartDate);
            if (election.Success == false)
            {
                ViewBag.Message = election.Message;
                return View();
            }
            ViewBag.Message = election.Message;
            return RedirectToAction("Index", "Election");
        }
    }
}