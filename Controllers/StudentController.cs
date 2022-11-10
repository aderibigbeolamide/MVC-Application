using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using MVCVottingApp.Data;
using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Implementation.Repository;
using MVCVottingApp.Implementation.Services;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;

namespace MVCVottingApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
       

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StudentSignUp() => View(new CreateStudentRequestModel());

        [HttpPost]
        public async Task<IActionResult> StudentSignUp(CreateStudentRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var student = await _studentService.CreateStudentAsync(model);
            if (student.Success == false)
            {
                ViewBag.Message = student.Message;
                return View(model);
            }
            ViewBag.Message = student.Message;
            return RedirectToAction("StudentLogin", "Login");
        }

        [HttpGet]
        public IActionResult StudentDashboard() => View();

        [HttpGet]
        public IActionResult EditProfile() => View();

        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateStudentRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var context = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var student = await _studentService.UpdateStudentAsync(model, Convert.ToInt32(context));
            if (student.Success == false)
            {
                ViewBag.Message = student.Message;
                return View(model);
            }
            ViewBag.Message = student.Message;
            return RedirectToAction("StudentDashboard", "Student");
        }

        [HttpGet]
        public IActionResult ApproveStudent() => View();

        [HttpPost]
        public async Task<IActionResult> ApproveStudent(int id)
        {
            var student = await _studentService.ApproveStudentAsync(id);
            if (student.Success == false)
            {
                ViewBag.Message = student.Message;
                return View();
            }
            ViewBag.Message = student.Message;
            return RedirectToAction("StudentDashboard", "Student");
        }

        [HttpGet]
        public IActionResult DeleteStudent() => View();

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.DeleteStudnetAsync(id);
            if (student.Success == false)
            {
                ViewBag.Message = student.Message;
                return View();
            }
            ViewBag.Message = student.Message;
            return RedirectToAction("StudentDashboard", "Student");
        }
    }
}