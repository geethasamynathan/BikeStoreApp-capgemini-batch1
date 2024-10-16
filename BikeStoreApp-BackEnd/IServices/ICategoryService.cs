using BikeStoreApp_BackEnd.DTO;

namespace BikeStoreApp_BackEnd.IServices
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO);
        Task DeleteCategory(int categoryId);
        Task<IEnumerable<CategoryDTO>> GetAllCategories();
        Task<CategoryDTO> GetCategoryById(int categoryId);
    }
}
