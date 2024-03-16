using LaboratorioBlazorUI.Auth.AuthModels;
using LaboratorioBlazorUI.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;

namespace LaboratorioBlazorUI.Auth
{
    public class JwtAuthStateProvider : AuthenticationStateProvider, ILoginServices
    {

        private IJSRuntime _js;
        private static readonly string TOKENKEY = "TOKENKEY";
        private readonly HttpClient _httpClient;
        private AuthenticationState anonimo = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        private NavigationManager _nav;

        public JwtAuthStateProvider(IJSRuntime js, HttpClient httpClient, NavigationManager nav)
        {
            _js = js;
            this._httpClient = httpClient;
            _nav = nav;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            var token = await _js.GetFromLocalStorage(TOKENKEY);

            if (string.IsNullOrEmpty(token))
            {
                return anonimo;
            }

            var authState = ConstruirAuthenticationState(token);

            if (VerificarSiExpiroElToken(token))
            {
                await Logout();
                _nav.NavigateTo("", true);
            }

            return authState;
        }

        private AuthenticationState ConstruirAuthenticationState(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsJwt(token), "jwt")));
        }

        //Antes era Async (hacia una peticion a la api), ya no hace falta
        private bool VerificarSiExpiroElToken(string token)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(token))
                    return false;
                if (!token.Contains("."))
                    return false;

                string[] parts = token.Split('.');

                JWToken payload = JsonSerializer.Deserialize<JWToken>(Base64UrlEncoder.Decode(parts[1]));

                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(payload.exp);

                var FechaExp = dateTimeOffset.LocalDateTime;

                if (FechaExp < DateTime.Now)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false; ;
            }
        }


        public async Task Login(string token)
        {
            await _js.SetInLocalStorage(TOKENKEY, token);
            var authState = ConstruirAuthenticationState(token);

            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task Logout()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
            await _js.RemoveItem(TOKENKEY);
            NotifyAuthenticationStateChanged(Task.FromResult(anonimo));
        }


        private IEnumerable<Claim> ParseClaimsJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);
            keyValuePairs.TryGetValue(ClaimTypes.Name, out object nombreUsuario);

            if (nombreUsuario != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, nombreUsuario.ToString()));
            }

            if (roles != null)
            {

                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var item in parsedRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return claims;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {

                case 2:
                    base64 += "==";
                    break;

                case 3:
                    base64 += "=";
                    break;

            }
            return Convert.FromBase64String(base64);

        }


    }
}
