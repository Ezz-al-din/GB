using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize("Admin")]
    [Route("api/controller")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpGet("employees")]
        public IEnumerable<string> Get()
        {
            return new List<string> {"Ahmed" , "Ali","Ahsan" };
        }
    }
}
