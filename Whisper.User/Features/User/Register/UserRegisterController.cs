using MediatR;
using Microsoft.AspNetCore.Mvc;
using Whisper.Shared.Features.Base;

namespace Whisper.User.Features.User.Register;

[ApiController]
[Route("api/users")]
public partial class UserController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<HandlerResponse<UserRegisterResponse>>> Register(
        [FromBody] UserRegisterRequest userRegisterRequest,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var result = await mediator.Send(userRegisterRequest, cancellationToken);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}