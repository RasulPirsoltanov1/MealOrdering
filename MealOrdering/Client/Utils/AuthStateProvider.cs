using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace MealOrdering.Client.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _localStorageService;
        private readonly AuthenticationState _anonymus;

        public AuthStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            _anonymus = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string apiToken = await _localStorageService.GetItemAsStringAsync("token");
            string email = await _localStorageService.GetItemAsStringAsync("email");
            if (string.IsNullOrEmpty(apiToken))
            {
                return _anonymus;
            }

            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            return new AuthenticationState(cp);
        }
        public void NotifyUserLogin(string email)
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var result=Task.FromResult(new AuthenticationState(cp));
            NotifyAuthenticationStateChanged(result);
        }
        public void NotifyUserLogout(string email)
        {
            var result = Task.FromResult(_anonymus);
            NotifyAuthenticationStateChanged(result);
        }
    }
}
