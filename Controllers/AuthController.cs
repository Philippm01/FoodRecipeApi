using Microsoft.AspNetCore.Mvc;
using FoodRecipeApi.DTOs;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FoodRecipeApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string FirebaseApiKey;

        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            FirebaseApiKey = Environment.GetEnvironmentVariable("FIREBASE_API_KEY") ?? string.Empty;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var payload = new
            {
                email = request.Email,
                password = request.Password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={FirebaseApiKey}",
                content);

            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(responseBody);
            }

            var json = JsonDocument.Parse(responseBody);
            var idToken = json.RootElement.GetProperty("idToken").GetString();

            return Ok(new LoginResponse { Token = idToken });
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> Register([FromBody] LoginRequest request)
        {
            var payload = new
            {
                email = request.Email,
                password = request.Password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={FirebaseApiKey}",
                content);

            var responseBody = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(responseBody);
            }

            var json = JsonDocument.Parse(responseBody);
            var idToken = json.RootElement.GetProperty("idToken").GetString();

            return Ok(new LoginResponse { Token = idToken });
        }
    }
}
