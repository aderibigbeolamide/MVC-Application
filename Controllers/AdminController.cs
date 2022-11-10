using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MVCVottingApp.Data;
using MVCVottingApp.ViewModel;
using MVCVottingApp.Interface.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Data.ViewModel.RequestModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MVCVottingApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IElectoralOfficerService _electoralOfficerService;
        private readonly IElectoralOfficerRepository _electoralOfficerRepository;

        public AdminController(MVCVottingAppContext mVCVottingAppContext)
        {
            _electoralOfficerRepository = new ElectoralOfficerRepository(mVCVottingAppContext);
            _electoralOfficerService = new ElectoralOfficerService(_electoralOfficerRepository);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminSignUp() => View(new CreateElectoralOfficerRequestModel());

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AdminSignUp(CreateElectoralOfficerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var electoral = await _electoralOfficerService.CreateElectoralOfficerAsync(model);
            if (electoral.Success == false)
            {
              ViewBag.Message = electoral.Message;
                return View(model);
            }
            ViewBag.Message = electoral.Message;
            return RedirectToAction("AdminLogin", "Login");
        }

         [HttpGet]
        public IActionResult AdminDashboard() => View();

        [HttpGet]
        public IActionResult EditProfile() => View();

        
        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateElectoralOfficerRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var context = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var electoral = await _electoralOfficerService.UpdateElectoralOfficerAsync(model, Convert.ToInt32(context));
            if (electoral.Success == false)
            {
                ViewBag.Message = electoral.Message;
                return View(model);
            }
            ViewBag.Message = electoral.Message;
            return RedirectToAction("AdminDashboard", "Admin");
        }


        [HttpGet]
        public IActionResult GetAllAdmins() => View();

        [HttpPost]
        public async Task<IActionResult> GetAllAdmin()
        {
            var electoral = await _electoralOfficerService.GetAllElectoralOfficersAsync();
            if (electoral.Success == false)
            {
                ViewBag.Message = electoral.Message;
                return View();
            }
            ViewBag.Message = electoral.Message;
            return View(electoral.Data);
        }

        [HttpGet]
        public IActionResult DeleteAdmin() => View();

        [HttpPost]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var electoral = await _electoralOfficerService.DeleteElectoralOfficerAsync(id);
            if (electoral.Success == false)
            {
                ViewBag.Message = electoral.Message;
                return View();
            }
            ViewBag.Message = electoral.Message;
            return RedirectToAction("AdminDashboard", "Admin");
        }
    }
}