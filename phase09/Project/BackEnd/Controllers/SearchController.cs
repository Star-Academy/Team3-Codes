using BackEnd.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Project.Utils;

namespace Project.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SearchController : ControllerBase
    {

        [HttpPost]
        public IActionResult GetMatchedResult([FromBody] InputString input)
        {
            var search = new Search();
            search.InitializeIndex();
            var result = search.SearchForSuitableDocs(input.Input);
            return Ok(result);
        }

    }
}