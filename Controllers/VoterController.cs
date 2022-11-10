using Microsoft.AspNetCore.Mvc;
using MVCVottingApp.Data;
using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

namespace MVCVottingApp.Controllers
{
    public class VoterController : Controller
    {
        private readonly IVoterService _voterService;
        private readonly IVoterRepository _voterRepository;

        public VoterController(MVCVottingAppContext mVCVottingAppContext)
        {
            _voterRepository = new VoterRepository(mVCVottingAppContext);
            _voterService = new VoterService(_voterRepository);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateVoter() => View(new CreateVoterRequestModel());

        [HttpPost]
        public async Task<IActionResult> CreateVoter(CreateVoterRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var voter = await _voterService.CreateVoterAsync(model);
            if (voter.Success == false)
            {
                ViewBag.Message = voter.Message;
                return View(model);
            }
            ViewBag.Message = voter.Message;
            return RedirectToAction("Index", "Voter");
        }

        [HttpGet]
        public IActionResult GetAllVoters() => View();

        [HttpPost]
        public async Task<IActionResult> GetAllVoters(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var voter = await _voterService.GetAllVotersAsync();
            if (voter.Success == false)
            {
                ViewBag.Message = voter.Message;
                return View();
            }
            ViewBag.Message = voter.Message;
            return RedirectToAction("Index", "Voter");
        }

        [HttpGet]
        public IActionResult GetVoterByMatricNumberForElection() => View();

        [HttpPost]
        public async Task<IActionResult> GetVoterByMatricNumberForElection(string matricNumber, int electionId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var voter = await _voterService.GetVoterByMatricNumberForElectionAsync(matricNumber, electionId);
            if (voter.Success == false)
            {
                ViewBag.Message = voter.Message;
                return View();
            }
            ViewBag.Message = voter.Message;
            return RedirectToAction("Index", "Voter");
        }
        
    }
}