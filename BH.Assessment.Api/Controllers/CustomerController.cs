using BH.Assessment.Application.Features.Customers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BH.Assessment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "UserInformation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<UserInformationVm>> GetUserInformation([FromQuery] Guid id)
    {
        var response = await _mediator.Send(new GetUserInformationQuery { CustomerId = id }).ConfigureAwait(false);
        return Ok(response);
    }
}