using AmazingShopPV113.Backend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace AmazingShopPV113.HttpApiClient
{
    public class AmazingShopClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _host;

        public AmazingShopClient(HttpClient httpClient, string host)
        {
            if (string.IsNullOrWhiteSpace(host))
            {
                throw new ArgumentException($"'{nameof(host)}' cannot be null or whitespace.", nameof(host));
            }

            if (httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            _httpClient = httpClient;
            _host = host;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            var uri = $"{_host}/api/products";
            var products = await _httpClient.GetFromJsonAsync<IReadOnlyList<Product>>(uri);
            return products!;
        }
    }
}
