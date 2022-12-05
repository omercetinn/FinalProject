using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //Dependence chain

            Thread.Sleep(1000);
            var result = _categoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);

        }
    }
}
