using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestingSystem.BLL.Services;
using TestingSystem.BLL;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using TestingSystem.BLL.Dtos;

namespace TestingSystem.PLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("jwttoken")]
        public ActionResult GetJWTToken(string username, string password)
        {
            var identity = _userService.GetClaimsIdentity(username, password);
            if(identity == null)
            {
                return BadRequest(EntityOperationResult<ClaimsIdentity>.Failture("No user with such login or password"));
            }
            var encodedJwt = _userService.GetEncodedJwtToken(identity);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(string username, string password)
        {
            var user = new UserDto()
            {
                UserName = username,
                Password = password,
                Role = "admin"
            };
            var result = _userService.AddUser(user);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
