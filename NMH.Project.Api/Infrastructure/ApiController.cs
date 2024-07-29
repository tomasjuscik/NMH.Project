namespace NMH.Project.Api.Infrastructure;

using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class ApiController : ControllerBase
{
    public ApiController(IMediator mediator) => Mediator = mediator;

    protected IMediator Mediator { get; }
}