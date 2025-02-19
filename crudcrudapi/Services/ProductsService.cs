using crudcrudapi.Models;
using crudcrudapi.Repositories;

namespace crudcrudapi.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _repository;

        public ProductsService(ProductsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _repository.GetAllProducts();
        }

        public async Task<Product?> GetProduct(string product_id)
        {
            return await _repository.GetProduct(product_id);
        }

        public async Task<Product> CreateProduct(ProductCreate productcreate_obj)
        {
            return await _repository.CreateProduct(productcreate_obj);
        }


        public async Task UpdateProduct(string product_id, Product product_obj)
        {
            await _repository.UpdateProduct(product_id, product_obj);
        }

        public async Task DeleteProduct(string product_id)
        {
            await _repository.DeleteProduct(product_id);
        }
    }
}
