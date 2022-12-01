using Microsoft.AspNetCore.Mvc; 

namespace Simple.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
