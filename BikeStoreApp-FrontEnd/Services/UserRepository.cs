using BikeStoreApp_BackEnd.IServices;
using BikeStoreApp_FrontEnd.IServices;
using BikeStoreApp_FrontEnd.Models;
using Newtonsoft.Json;
using System.Text;

namespace BikeStoreApp_FrontEnd.Services
{
    public class UserRepository:IUserRepository
    {
        private readonly HttpClient _httpClient;

        public UserRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var jsonContent = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/users/register", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonResponse);
            }
            return null;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var jsonContent = JsonConvert.SerializeObject(new { username, password });
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/users/login", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonResponse);
            }
            return null;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"/api/users/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonResponse);
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var response = await _httpClient.GetAsync("/api/users");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonResponse);
            }
            return null;
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            var jsonContent = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"/api/users/{user.UserId}", content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/users/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var response = await _httpClient.GetAsync($"/api/users/username/{username}");
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(jsonResponse);
            }
            return null;
        }
    }
}
