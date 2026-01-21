using Microsoft.AspNetCore.Mvc;
using PokemonApp.Web.Models;
using System.Diagnostics;
using PokemonApp.AppLogic;

namespace PokemonApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IPokemonRepository pokemonRepository, ILogger<HomeController> logger)
        {
            _pokemonRepository = pokemonRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_pokemonRepository.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
