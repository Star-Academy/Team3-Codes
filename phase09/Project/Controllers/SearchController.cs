using Microsoft.AspNetCore.Mvc;
using Project.Utils;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SearchController : ControllerBase
    {

        [HttpPost]
        public IActionResult GetMatchedResult([FromBody] string input)
        {
            var search = new Search();
            search.Connect();
            search.InitializeIndex();

            var result = search.SearchForSuitableDocs(input);
            return Ok(result);
        }

    }
}