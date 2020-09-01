using Learning.Model;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SimpleController : ControllerBase
    {
        private readonly IPerson person;

        public SimpleController(IPerson person)
        {
            this.person = person;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Student().GetPerson());
        }

        [HttpPost]
        public IActionResult Get1([FromBody] string message)
        {
            return Ok(new string (message+" my friend"));
        }
    }
}