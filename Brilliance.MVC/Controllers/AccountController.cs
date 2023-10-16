using Brilliance.API.Client;
using Brilliance.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Brilliance.MVC.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class AccountController : Controller
    {
        private readonly IBrilliance _brilliance;
        public AccountController(IBrilliance brilliance)
            => _brilliance = brilliance;

        [AllowAnonymous]
        public IActionResult SignUp()
            => View();
        [AllowAnonymous]
        public IActionResult SignIn()
            => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserDTO userDTO)
        {
            try
            {
                var response = await _brilliance.Authorization(userDTO);
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userDTO.Username),
                    new Claim(ClaimTypes.Role, new JwtSecurityTokenHandler()
                        .ReadJwtToken(response)
                        .Claims.FirstOrDefault(claim => claim.Type == "role")?.Value),
                    new Claim("AccessToken", response)
                }, CookieAuthenticationDefaults.AuthenticationScheme)),
                new AuthenticationProperties() { IsPersistent = true });
                return Redirect("/");
            }
            catch(ApiException) 
            {
                return View("SignIn", userDTO);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        public IActionResult Profile()
            => View();
    }
}
