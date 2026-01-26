using Asp.Versioning;

namespace Circulars.API.Controller
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class BaseController : ControllerBase
    {
       
    }
}
