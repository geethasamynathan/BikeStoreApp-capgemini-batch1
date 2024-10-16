//namespace BikeStoreApp_BackEnd.Controllers
//{
//    public class UsersController
//    {
//    }
//}
using BikeStoreApp_BackEnd.DTO;
using BikeStoreApp_BackEnd.IServices;
using BikeStoreApp_BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStrore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                Password = userDto.Password,  // You can hash this password here
                Role = "User"
            };

            var createdUser = await _userRepository.RegisterAsync(user);
            return Ok(createdUser);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            var user = await _userRepository.LoginAsync(loginDto.UserName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            // Normally, you generate a JWT token here, for simplicity we just return user data
            return Ok(user);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            // Assume you get the logged-in user's ID somehow (e.g., via JWT token)
            int userId = 1; // Example userId
            var user = await _userRepository.GetUserByIdAsync(userId);
            return Ok(user);
        }

        [HttpPut("profile/{userId}")]
        public async Task<IActionResult> UpdateProfile(int userId, [FromBody] UserRegisterDto userDto)
        {
            // Fetch the user by the provided userId
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {userId} not found." });
            }

            // Update user properties
            user.UserName = userDto.UserName;
            user.Email = userDto.Email;
            user.Password = userDto.Password; // Hash password if needed

            await _userRepository.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Implement logout logic here (JWT token invalidation, etc.)
            return Ok("Logged out successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            var userDtos = users.Select(user => new UserProfileDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role
            });

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var users = await _userRepository.GetUserByIdAsync(id);
            if (users == null)
            {
                // If user not found, return 404
                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            // Map the user entity to the UserProfileDto
            var userDto = new UserProfileDto
            {
                UserId = users.UserId,
                UserName = users.UserName,
                Email = users.Email,
                Role = users.Role
            };

            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUserAsync(id);
            if (!result)
                return NotFound();


            return Ok("User deleted successfully");
        }
    }
}

