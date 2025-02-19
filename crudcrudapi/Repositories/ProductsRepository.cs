using System.Net.Http.Json;
using System.Text.Json.Serialization;
using crudcrudapi.Models;
using Newtonsoft.Json;

namespace crudcrudapi.Repositories
{
    public class ProductsRepository
    {
        private readonly HttpClient _httpClient;

        public ProductsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Console.WriteLine($"Base Address: {_httpClient.BaseAddress}");
        }

        // Get all products
        public async Task<List<Product>> GetAllProducts()
        {
            var a = _httpClient;
            var products = await _httpClient.GetFromJsonAsync<List<Product>>("products");
            return products ?? new List<Product>();
        }

        // Get a single product by ID
        public async Task<Product?> GetProduct(string product_id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Product?>($"products/{product_id}");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error fetching product with ID {product_id}: {ex.Message}", ex);
            }
        }

        // Create a new product
        public async Task<Product> CreateProduct(ProductCreate productcreate_obj)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("products", productcreate_obj);
                response.EnsureSuccessStatusCode();

                // Deserialize the response to get the created product
                var createdProduct = await response.Content.ReadFromJsonAsync<Product>();
                return createdProduct!;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error creating product: {ex.Message}", ex);
            }
        }


        // Update an existing product
        public async Task UpdateProduct(string product_id, Product product_obj)
        {
            try
            {
                var product = new
                {
                    Name = product_obj.Name,
                    Description = product_obj.Description,
                    Price = product_obj.Price
                };

                var response = await _httpClient.PutAsJsonAsync($"products/{product_id}", product);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error updating product with ID {product_id}: {ex.Message}", ex);
            }
        }


            // Delete a product by ID
        public async Task DeleteProduct(string product_id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"products/{product_id}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error deleting product with ID {product_id}: {ex.Message}", ex);
            }
        }
    }
}
