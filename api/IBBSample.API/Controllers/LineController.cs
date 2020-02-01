using LineStopRoute;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IBBSample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ControllerBase
    {
        private readonly WebService1Soap _lineStopRoute;
        public LineController(WebService1Soap lineStopRoute)
        {
            _lineStopRoute = lineStopRoute;
        }

        /// <summary>
        /// terminalId boş gönderilirse tüm veriyi dönüyor. Bu hem İBB hem de bizim için katlanılabilir bir durum değil:)
        /// Bu yüzden örnek olarak 225972 numaralı durağı deneyin.
        /// [{"SDURAKKODU":225972,"SDURAKADI":"MERCAN YUVASI","KOORDINAT":"POINT (29.2763499999941 40.8183030005252)","ILCEADI":"Tuzla","SYON":"SON DURAK","AKILLI":"YOK","FIZIKI":"AÇIK","DURAK_TIPI":"İETTBAYRAK"}]
        /// </summary>
        /// <param name="terminalId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{terminalId}")]//225972
        public async Task<ActionResult<string>> Get(string terminalId)
        {
            var result = await _lineStopRoute.GetDurak_jsonAsync(
                new GetDurak_jsonRequest(new GetDurak_jsonRequestBody(terminalId.ToString())));
            return Ok(result.Body?.GetDurak_jsonResult);
        }
    }
}