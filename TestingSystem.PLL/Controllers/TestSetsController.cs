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
    }
}
