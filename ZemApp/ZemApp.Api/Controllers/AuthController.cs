using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ZemApp.Api.Model;
using ZemApp.Application.GenerateSampleData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZemApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;
        private ISampleDataUtil _sampleDataUtil;
        public IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration config, ISampleDataUtil sampleDataUtil)
        {
            _sampleDataUtil = sampleDataUtil;

            _userService = userService;
            _configuration = config;
            if (!_sampleDataUtil.HasDataLoad())
                _sampleDataUtil.GenerateData();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login(AuthModel model)
        {

            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}