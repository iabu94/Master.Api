using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MRX.Master.Api.Controllers
{
    [Route("api/grades")]
    public class GradeController : MasterControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }
    }
}
