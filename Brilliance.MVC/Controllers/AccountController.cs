using Brilliance.API.Client;
using Brilliance.Domain.Models;
using Brilliance.Domain.Models.DTO;
using Brilliance.Domain.Models.Requests;
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
        private readonly IUserClient _userClient;
        public AccountController(IUserClient userClient)
            => _userClient = userClient;

        [AllowAnonymous]
        public IActionResult SignUp()
            => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(UserRequest user)
        {
            try
            {
                await _userClient.CreateUser(user);
                return RedirectToAction("SignIn");
            }
            catch (ApiException)
            {
                return View("SignUp", user);
            }
        }

        [AllowAnonymous]
        public IActionResult SignIn()
            => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserRequest user)
        {
            try
            {
                var response = await _userClient.Authorization(user);
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username),
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
                return View("SignIn", user);
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
