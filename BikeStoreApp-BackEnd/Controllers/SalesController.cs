using BikeStoreApp_BackEnd.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BikeStoreApp_BackEnd.Controllers
{
    public class SalesController:ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISalesService _salesService;

        public SalesController(IProductService productService, ICategoryService categoryService, ISalesService salesService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _salesService = salesService;
        }
        // View Sales Reports
        [HttpGet("sales/reports")]
        public async Task<IActionResult> GetSalesReports(string frequency)
        {
            var reports = await _salesService.GetSalesReports(frequency);
            return Ok(reports);
        }
    }
}
