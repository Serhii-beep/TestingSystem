using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.BLL.Services;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL;
using System.Collections.Generic;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TestCategoriesController : ControllerBase
    {
        private readonly TestCategoryService _testCategoryService;

        public TestCategoriesController(TestCategoryService testCategoryService)
        {
            _testCategoryService = testCategoryService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<EntityOperationResult<IEnumerable<TestCategoryDto>>> GetAllTestCategories()
        {
            var result = _testCategoryService.GetAllCategories();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
