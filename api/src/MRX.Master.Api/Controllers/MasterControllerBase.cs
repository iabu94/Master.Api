using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using MRX.Master.Api.DTOs;

namespace MRX.Master.Api.Controllers
{
    [ApiController]
    public abstract class MasterControllerBase : ControllerBase
    {
        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object error)
        {
            return new BadRequestObjectResult(new ErrorResultDto
            {
                Message = error.ToString(),
                CorrelationId = Request.HttpContext.TraceIdentifier
            });
        }
    }
}
