using WebAPIAutores.Entities;

namespace AuthorsWebApplication.Services
{
    public class ApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ApiService> _logger;

        public ApiService(IHttpClientFactory clientFactory, ILogger<ApiService> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7277/api/books");
            var client = _clientFactory.CreateClient("MyApiClient");

            HttpResponseMessage response = await client.SendAsync(request);

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

        // TODO: Implement other methods for POST, PUT, DELETE
    }
}
