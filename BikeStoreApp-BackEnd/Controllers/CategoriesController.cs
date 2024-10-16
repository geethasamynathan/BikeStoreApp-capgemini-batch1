using AutoMapper;
using BikeStoreApp_BackEnd.DTO;
using BikeStoreApp_BackEnd.Exceptions;
using BikeStoreApp_BackEnd.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreApp_BackEnd.Controllers
{
    public class CategoriesController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISalesService _salesService;

        public CategoriesController(IMapper mapper, IProductService productService, ICategoryService categoryService, ISalesService salesService)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _salesService = salesService;
        }

        // Manage Categories
        [HttpPost("categories")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO categoryDTO)
        {
            var createdCategory = await _categoryService.AddCategory(categoryDTO);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }

        [HttpDelete("categories/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            return NoContent();
        }


        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                return Ok(category);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
