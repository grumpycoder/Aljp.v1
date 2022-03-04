using Aljp.Application.MiniBid.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "MiniBids")]
public class MiniBidsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MiniBidsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        //return Ok();
        var list = await _mediator.Send(new GetAllMiniBids.Query(), token); 
        return Ok(list);
    }
    
    [HttpGet]
    [Route("{id:int}", Name = nameof(GetMiniBidById))]
    public async Task<ActionResult> GetById([FromRoute] int id, CancellationToken token = new())
    {
        var entity = await _mediator.Send(new GetMiniBidById.Query(id), token);
        return Ok(entity);
    }
}