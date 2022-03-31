using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.BLL;
using TestingSystem.BLL.Dtos;
using TestingSystem.BLL.Services;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionsController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost]
        [Route("addQuestion")]
        public ActionResult<EntityOperationResult<QuestionDto>> AddQuestion(QuestionDto question)
        {
            var result = _questionService.AddQuestion(question);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
