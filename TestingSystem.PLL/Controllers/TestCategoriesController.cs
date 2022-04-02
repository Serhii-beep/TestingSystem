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

        [HttpGet]
        [Route("getAll")]
        public ActionResult<EntityOperationResult<IEnumerable<TestCategoryDto>>> GetAllTestCategories()
        {
            var result = _testCategoryService.GetAllCategories();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public ActionResult<EntityOperationResult<TestCategoryDto>> GetTestCategoryById(int id)
        {
            var result = _testCategoryService.GetCategoryById(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("delete/{testCategoryId}")]
        public ActionResult<EntityOperationResult<bool>> DeleteTestCategory(int testCategoryId)
        {
            var result = _testCategoryService.DeleteCategory(testCategoryId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("post")]
        [Authorize(Roles = "admin")]
        public ActionResult<EntityOperationResult<TestCategoryDto>> AddTestCategory(TestCategoryDto testCategoryDto)
        {
            var result = _testCategoryService.AddCategory(testCategoryDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        [Route("{testCategoryId}")]
        public ActionResult<EntityOperationResult<TestCategoryDto>> UpdateTestCategory(int testCategoryId, TestCategoryDto testCategoryDto)
        {
            var result = _testCategoryService.UpdateCategory(testCategoryId, testCategoryDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
