using BH.Assessment.Application.Features.Accounts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BH.Assessment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost(Name = "addAccount")]
    public async Task<ActionResult<CreateAccountResponse>> CreateAccount([FromBody] CreateAccountCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}