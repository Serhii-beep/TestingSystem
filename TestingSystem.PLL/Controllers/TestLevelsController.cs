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
    }
}
