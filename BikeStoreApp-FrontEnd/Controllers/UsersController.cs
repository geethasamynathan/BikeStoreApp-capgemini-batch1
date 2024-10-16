using BikeStoreApp_FrontEnd.Models;
using BikeStoreApp_FrontEnd.Services;

//using BikeStoreApp_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreApp_FrontEnd.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserRepository _userRepository;

        public UsersController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var registeredUser = await _userRepository.RegisterAsync(user);
            if (registeredUser != null)
            {
                return RedirectToAction("Index");
            }

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = await _userRepository.LoginAsync(username, password);
            if (user != null)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }
    }
}

