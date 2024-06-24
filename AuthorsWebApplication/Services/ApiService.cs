using WebAPIAutores.Entities;

namespace AuthorsWebApplication.Services
{
    public class ApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ApiService> _logger;
        private readonly HttpClient client; 

        public ApiService(IHttpClientFactory clientFactory, ILogger<ApiService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
            this.client = _clientFactory.CreateClient("MyApiClient");
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://localhost:7277/api/books");

            HttpResponseMessage response = await this.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<Book>>();
            }
            else
            {
                _logger.LogError("Error fetching books");
                return null;
            }
        }

        public async Task<Book> GetBookAsync(int? id)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://localhost:7277/api/books/{id}");

            HttpResponseMessage response = await this.client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Book>();
            }
            else
            {
                _logger.LogError($"Error fetching the book with Id:{id}");
                return null;
            }
        }

        // TODO: Implement other methods for POST, PUT, DELETE
    }
}
