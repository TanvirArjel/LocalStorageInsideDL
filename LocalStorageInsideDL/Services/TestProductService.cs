using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LocalStorageInsideDL.Services
{
    public class TestProductService
    {
        private readonly HttpClient _httpClient;

        public TestProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("TestApi");
        }

        public async Task<List<ProductModel>> GetListAsync()
        {
            List<ProductModel> productModels = await _httpClient.GetFromJsonAsync<List<ProductModel>>("api/products");
            return productModels;
        }
    }
}
