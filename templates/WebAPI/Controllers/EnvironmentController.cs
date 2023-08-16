using Microsoft.AspNetCore.Mvc;

namespace api_template_dot_net_core_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public EnvironmentController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        [Route("EnvironmentName")]
        public string GetEnvironmentName()
        {
            return _environment.EnvironmentName;
        }

        [HttpGet]
        [Route("ApplicationName")]
        public string GetApplicationName()
        {
            return _environment.ApplicationName;
        }

        [HttpGet]
        [Route("ContentRootPath")]
        public string GetContentRootPath()
        {
            return _environment.ContentRootPath;
        }
    }
}
