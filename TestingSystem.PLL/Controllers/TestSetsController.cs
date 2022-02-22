using TestingSystem.BLL;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestSetsController : ControllerBase
    {
        private readonly TestSetService _testSetService;

        public TestSetsController(TestSetService testSetService)
        {
            _testSetService = testSetService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<EntityOperationResult<IEnumerable<TestSetDto>>> GetAllTestSets()
        {
            var result = _testSetService.GetAllTestSets();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("getByCategory/{categoryId}")]
        public ActionResult<EntityOperationResult<IEnumerable<TestSetDto>>> GetTestSetsByCategory(int categoryId)
        {
            var result = _testSetService.GetTestSetsByCategory(categoryId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("getByLevel/{testLevelId}")]
        public ActionResult<EntityOperationResult<IEnumerable<TestSetDto>>> GetTestSetsByLevel(int testLevelId)
        {
            var result = _testSetService.GetTestSetsByLevel(testLevelId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("getByLevelCategory/levelId={testLevelId}&categoryId={testCategoryId}")]
        public ActionResult<EntityOperationResult<IEnumerable<TestSetDto>>> GetTestSetsByLevelCategory(int testLevelId, int testCategoryId)
        {
            var result = _testSetService.GetTestsByLevelCategory(testLevelId, testCategoryId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpDelete]
        [Route("delete/testSetId={testSetId}")]
        public ActionResult<EntityOperationResult<bool>> DeleteTestSet(int testSetId)
        {
            var result = _testSetService.DeleteTestSet(testSetId);
            return result.IsSuccess ? NoContent() : BadRequest(result);
        }

        [HttpPost]
        [Route("post")]
        public ActionResult<EntityOperationResult<TestSetDto>> AddTestSet(TestSetDto testSetDto)
        {
            var result = _testSetService.AddTestSet(testSetDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result); // createdAtAction?
        }

        [HttpPut("{testSetId}")]
        public ActionResult<EntityOperationResult<TestSetDto>> UpdateTestSet(int testSetId, TestSetDto testSetDto)
        {
            var result = _testSetService.UpdateTestSet(testSetId, testSetDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        
    }
}
