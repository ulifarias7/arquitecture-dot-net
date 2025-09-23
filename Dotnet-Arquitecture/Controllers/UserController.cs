using Application.Common.Models;
using Application.UseCases.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Arquitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {

        [HttpGet("get-user-by-id")]
        public async Task<ActionResult<ResponseObjectJson>> GetUserById([FromQuery] GetUserByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
