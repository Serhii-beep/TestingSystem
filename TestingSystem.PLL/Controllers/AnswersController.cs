using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.BLL;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Services;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly AnswerService _answerService;

        public AnswersController(AnswerService answerService)
        {
            _answerService = answerService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("addAnswer")]
        public ActionResult<EntityOperationResult<AnswerDto>> AddAnswer(AnswerDto answer)
        {
            var result = _answerService.AddAnswer(answer);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        [Route("deleteAnswer/{answerId}")]
        public ActionResult<EntityOperationResult<bool>> DeleteAnswer(int answerId)
        {
            var result = _answerService.DeleteAnswer(answerId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
