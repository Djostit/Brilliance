using Brilliance.API.Client;
using Brilliance.Database.Entities;
using Brilliance.Domain.Models.DTO;
using Brilliance.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace Brilliance.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostClient _postClient;
        public PostController(IPostClient postClient)
        {
            _postClient = postClient;
        }
        public async Task<IActionResult> Details([FromRoute] int id) 
            => View();
        public IActionResult Index()
            => View();

        [Microsoft.AspNetCore.Authorization.Authorize]
        public IActionResult Create()
            => View();

        [Microsoft.AspNetCore.Authorization.Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PostRequest post)
        {
            try
            {
                await _postClient.CreatePost(post);
                return Redirect("/");
            }
            catch (ApiException)
            {
                return View("Create", post);
            }
        }
    }
}
