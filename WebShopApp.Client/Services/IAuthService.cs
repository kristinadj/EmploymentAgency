using Blazored.LocalStorage;
using EmploymentAgency.DTO;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using WebShopApp.Client.Helpers;

namespace WebShopApp.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResultDTO> Login(LoginDTO model);
        Task Logout();
        Task<bool> Register(UserDTO model);
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<LoginResultDTO> Login(LoginDTO model)
        {
            var content = JsonSerializer.Serialize(model);
            var response = await _httpClient.PostAsync("api/Users/Authenticate", new StringContent(content, Encoding.UTF8, "application/json"));

            if (!response.IsSuccessStatusCode)
                return null;

            var loginResult = JsonSerializer.Deserialize<LoginResultDTO>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(model.Username);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);
            
            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<bool> Register(UserDTO model)
        {
            var content = JsonSerializer.Serialize(model);
            var response = await _httpClient.PostAsync("api/Users/Register", new StringContent(content, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
