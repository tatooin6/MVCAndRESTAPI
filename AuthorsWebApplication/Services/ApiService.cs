using System.Text;
using System.Text.Json;
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

        public async Task<Book> UpdateBookASync(Book book, int id)
        {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            var jsonString = JsonSerializer.Serialize(book, options);
            _logger.LogInformation($"Sending JSON: {jsonString}");
            var request = new HttpRequestMessage(
                HttpMethod.Put,
                $"https://localhost:7277/api/books/{id}"
            )
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };

            // handling response
            try
            {
                HttpResponseMessage response = await this.client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Book>();
                }
                else
                {
                    _logger.LogError($"Error updating book. Id:{id}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception during update: {ex.Message}");
                return null;
            }
        }

        public async Task<Book> CreateBookAsync(Book book) {
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
            };
            try
            {
                var response = await this.client
                    .PostAsJsonAsync<Book>(
                        "https://localhost:7277/api/books",
                        book,
                        options
                    );
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Book>();
                }
                else
                {
                    _logger.LogError($"Exception during book creation");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception during update: {ex.Message}");
                return null;
            }
        }

        // TODO: Implement other methods for DELETE
    }
}
