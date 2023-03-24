using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Upd8.Core.Shared.ViewModels;

namespace Upd8.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            //var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            //var exception = context?.Error;

            Response.StatusCode = StatusCodes.Status500InternalServerError;
            var erroId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            return new ErrorResponse(erroId);
        }
    }
}
