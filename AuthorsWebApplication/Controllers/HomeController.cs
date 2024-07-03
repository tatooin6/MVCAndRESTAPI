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

        public async Task<IActionResult> Index()
        {
            //var books = await GetBooks();
            var books = await _apiService.GetBooksAsync();
            if (books == null)
            {
                books = new List<Book>();
            }
            return View(books);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _apiService.GetBookAsync(id);
            return View(book);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Show Edit Form
        [HttpGet]
        public async Task<ActionResult> Edit(int id) {
            var book = await _apiService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Handle book update
        [HttpPost]
        public async Task<ActionResult> Edit(Book book) {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var updatedBook = await _apiService.UpdateBookASync(book, book.Id);
            if (updatedBook != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Book book) {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var createdBook = await _apiService.CreateBookAsync(book);
            if (createdBook != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
