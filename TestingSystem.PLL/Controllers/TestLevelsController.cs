using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Services;
using System.Collections.Generic;
using TestingSystem.BLL;
using Microsoft.AspNetCore.Mvc;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestLevelsController : ControllerBase
    {
        private readonly TestLevelService _testLevelService;

        public TestLevelsController(TestLevelService testLevelService)
        {
            _testLevelService = testLevelService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<EntityOperationResult<IEnumerable<TestLevelDto>>> GetAllTestLevels()
        {
            var result = _testLevelService.GetAllTestLevels();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("delete/{testLevelId}")]
        public ActionResult<EntityOperationResult<bool>> DeleteTestLevel(int testLevelId)
        {
            var result = _testLevelService.DeleteTestLevel(testLevelId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("post")]
        public ActionResult<EntityOperationResult<TestLevelDto>> AddTestLevel(TestLevelDto testLevelDto)
        {
            var result = _testLevelService.AddTestLevel(testLevelDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("put/{testLevelId}")]
        public ActionResult<EntityOperationResult<TestLevelDto>> UpdateTestLevel(int testLevelId, TestLevelDto testLevelDto)
        {
            var result = _testLevelService.UpdateTestLevel(testLevelId, testLevelDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
