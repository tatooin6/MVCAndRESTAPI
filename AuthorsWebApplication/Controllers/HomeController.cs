using AuthorsWebApplication.Models;
using AuthorsWebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAPIAutores.Entities;

namespace AuthorsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly ApiService _apiService;

        public HomeController(
            ILogger<HomeController> logger,
            HttpClient httpClient,
            ApiService apiService)
        {
            _logger = logger;
            _httpClient = httpClient;
            _apiService = apiService;
        }

        // private async Task<IEnumerable<Book>> GetBooks()
        // {
        //     var url = "https://localhost:7277/api/books";
        //     return await _httpClient
        //         .GetFromJsonAsync<IEnumerable<Book>>(url);
        // }

        public async Task<IActionResult> Index()
        {
            //var books = await GetBooks();
            var books = await _apiService.GetBooksAsync();
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
