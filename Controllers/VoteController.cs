using Microsoft.AspNetCore.Mvc;
using MVCVottingApp.Data;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

namespace MVCVottingApp.Controllers
{
    public class VoteController : Controller
    {
        private readonly IVoteService _voteService;
        private readonly IVoteRepository _voteRepository;

        public VoteController(MVCVottingAppContext mVCVottingAppContext)
        {
            _voteRepository = new VoteRepository(mVCVottingAppContext);
            _voteService = new VoteService(_voteRepository);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CastVote() => View();

        [HttpPost]
        public async Task<IActionResult> CastVote(int VoterId)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var vote = await _voteService.CastVoteAsync(VoterId);
            if (vote.Success == false)
            {
                ViewBag.Message = vote.Message;
                return View();
            }
            ViewBag.Message = vote.Message;
            return RedirectToAction("Index", "Vote");
        }

        [HttpGet]
        public IActionResult GetAllVotes() => View();

        [HttpPost]
        public async Task<IActionResult> GetAllVotes(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var vote = await _voteService.GetAllVotesAsync();
            if (vote.Success == false)
            {
                ViewBag.Message = vote.Message;
                return View();
            }
            ViewBag.Message = vote.Message;
            return RedirectToAction("Index", "Vote");
        }

        // [HttpGet]
        // public IActionResult GetHighestVoteByContestantId() => View();

        // [HttpPost]
        // public async Task<IActionResult> GetHighestVoteByContestantId(int contestantId)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View();
        //     }
        //     var vote = await _voteService.GetHighestVoteByContestantIdAsync(contestantId);
        //     if (vote.Success == false)
        //     {
        //         ViewBag.Message = vote.Message;
        //         return View();
        //     }
        //     ViewBag.Message = vote.Message;
        //     return RedirectToAction("Index", "Vote");
        // }

    }
}