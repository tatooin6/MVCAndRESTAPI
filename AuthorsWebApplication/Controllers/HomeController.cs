using AuthorsWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIAutores.Entities;

namespace AuthorsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        private async Task<IEnumerable<Book>> GetBooks()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Book>>("https://localhost:7277/api/books");
        }

        public async Task<IActionResult> Index()
        {
            var books = await GetBooks();
            return View(books);
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
