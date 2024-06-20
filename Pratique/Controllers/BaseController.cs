using Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Result(ApiReponse response)
        {
            if (response.Result == "OK")
            {
                return Ok(response.Data);
                // code 200 + message  response body
            }
            else
            {
                // code response.Code response body
                HttpContext.Response.StatusCode = Convert.ToInt32(response.Code);
                return Content(response.ResultDescription);

            }
        }
    }
}
