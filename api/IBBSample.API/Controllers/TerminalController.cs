using LineStopRoute;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IBBSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private readonly WebService1Soap _lineStopRoute;
        public TerminalController(WebService1Soap lineStopRoute)
        {
            _lineStopRoute = lineStopRoute;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var result = await _lineStopRoute.GetGaraj_jsonAsync(new GetGaraj_jsonRequest());
            return Ok(result.Body?.GetGaraj_jsonResult);
        }
    }
}