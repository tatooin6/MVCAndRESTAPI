using AuthorsWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthorsWebApplication.Controllers
{
    public class AuthorsController: Controller
    {
        private readonly ILogger<AuthorsController> _authorsLogger;
        private readonly ApiService _apiService;
        public AuthorsController(ILogger<AuthorsController> logger, ApiService apiService)
        {
            this._authorsLogger = logger;
            this._apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }
            
    }
}