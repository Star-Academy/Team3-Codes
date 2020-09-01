using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello world!";
        }
        [HttpGet]
        public string newGet()
        {
            return "Hello world more :)!";
        }
    }
}