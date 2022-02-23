using Microsoft.AspNetCore.Mvc;
using TestingSystem.BLL.Services;
using TestingSystem.BLL;
using System.Collections.Generic;
using TestingSystem.BLL.Dtos;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly TestService _testService;

        public TestsController(TestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        [Route("getTests/{testSetId}")]
        public ActionResult<EntityOperationResult<List<TestReadDto>>> GetTests(int testSetId)
        {
            var result = _testService.GetTests(testSetId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("checkAnswer/{testId}&{answerId}")]
        public ActionResult<EntityOperationResult<bool>> CheckAnswer(int testId, int answerId)
        {
            var result = _testService.CheckAnswer(testId, answerId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete]
        [Route("delete/testId={testId}")]
        public ActionResult<EntityOperationResult<bool>> DeleteTest(int testId)
        {
            var result = _testService.DeleteTest(testId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
