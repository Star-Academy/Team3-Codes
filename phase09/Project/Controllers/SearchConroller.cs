using Microsoft.AspNetCore.Mvc;
using Project.Utils;

namespace Project.Controllers
{
    public class SearchConroller
    {
        [ApiController]
        [Route("[controller]/[Action]")]
        public class SimpleController : ControllerBase
        {
            [HttpPost]
            public IActionResult GetMatchedResult([FromBody] string input)
            {
                var manager = new Manager();
                var result = manager.Search(input);
                return Ok(result);
            }
        }

    }
}