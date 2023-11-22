using Brilliance.API.Client;
using Brilliance.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Brilliance.MVC.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IPost _post;
        //public HomeController(IPost post)
        //    => _post = post;
        public async Task<IActionResult> Index()
            => View();

        public IActionResult Privacy()
            => View();

        public IActionResult AccessDenied() 
            => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}