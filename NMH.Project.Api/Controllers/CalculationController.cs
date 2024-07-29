namespace NMH.Project.Api.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using NMH.Project.Api.Infrastructure;
using NMH.Project.Application.Calculation.Command.Calculation;

public class CalculationController : ApiController
{
    public CalculationController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost(ApiRoutes.CalculationRoute.Calculation)]
    [ProducesResponseType<CalculationResponse>(StatusCodes.Status200OK)]
    public async Task<IActionResult> Calculation(
        [FromRoute] int key, 
        [FromBody] CalculationRequest request, CancellationToken ct)
    {
        var command = new CalculationCommand(key, request.Input);
        var res = await Mediator.Send(command, ct);
        return Ok(res);
    }
}