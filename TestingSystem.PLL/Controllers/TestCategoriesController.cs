using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.BLL.Services;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<EntityOperationResult<IEnumerable<TestCategoryDto>>> GetAllTestCategories()
        {
            var result = _testCategoryService.GetAllCategories();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("delete/{testCategoryId}")]
        public ActionResult<EntityOperationResult<bool>> DeleteTestCategory(int testCategoryId)
        {
            var result = _testCategoryService.DeleteCategory(testCategoryId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("post")]
        public ActionResult<EntityOperationResult<TestCategoryDto>> AddTestCategory(TestCategoryDto testCategoryDto)
        {
            var result = _testCategoryService.AddCategory(testCategoryDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("{testCategoryId}")]
        public ActionResult<EntityOperationResult<TestCategoryDto>> UpdateTestCategory(int testCategoryId, TestCategoryDto testCategoryDto)
        {
            var result = _testCategoryService.UpdateCategory(testCategoryId, testCategoryDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
