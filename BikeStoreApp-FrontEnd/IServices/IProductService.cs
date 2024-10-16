using BikeStoreApp_BackEnd.DTO;
using BikeStoreApp_FrontEnd.Models;
//using BikeStoreApp_BackEnd.Models;

namespace BikeStoreApp_BackEnd.IServices
{
    public interface IProductService
    {
        Task<ProductDTO> AddProduct(ProductDTO productDTO);
        Task<ProductDTO> UpdateProduct(int productId, ProductDTO productDTO);
        Task DeleteProduct(int productId);
        Task<IEnumerable<ProductDTO>> GetAllProducts();
        Task<ProductDTO?> GetProductById(int productId);
        Task<List<ProductDTO>> GeBikesByCategory(string category);
        Task<Product> GetBikeByBrand(string brand);
        Task<Product> GetBikeBySearch(string searchBy, string filterValue);

    }
}
