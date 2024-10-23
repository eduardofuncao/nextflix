using Microsoft.AspNetCore.Mvc;
using NextFlix.Models;
using System.Diagnostics;

namespace NextFlix.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); // Carrega a view Index de Home
        }

        public IActionResult Privacy()
        {
            return View("Privacy"); // Carrega a view Privacy
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); // Carrega a view Error
        }
    }
}