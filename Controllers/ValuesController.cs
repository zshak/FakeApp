using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;


namespace DataGetter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : ControllerBase
    {
        private readonly IFakeAppService _appService;

        public ValuesController(IFakeAppService appService)
        {
            _appService = appService;
        }

        [HttpGet ("/products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok( await _appService.GetAllProducts());
        }

        [HttpGet("/products/categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _appService.GetCategories());
        }

        [HttpGet("/products/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _appService.GetProductByID(id));
        }

        [HttpGet("/products/category/{category}")]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            return Ok(await _appService.GetProductByCategory(category));
        }

        [HttpGet("/carts")]
        public async Task<IActionResult> GetCartById(int id)
        {
            return Ok(await _appService.GetCartById(id));
        }

        [HttpGet("/products/[action]/{limit}")]
        public async Task<IActionResult> GetProductByLimit(int limit)
        {
            return Ok(await _appService.GetProductsByLimit(limit));
        }
    }
}
