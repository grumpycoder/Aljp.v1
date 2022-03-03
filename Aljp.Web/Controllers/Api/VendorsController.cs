using Aljp.Application.Vendor.Commands;
using Aljp.Application.Vendor.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aljp.Web.Controllers.Api;

[ApiController]
[Route("api/[controller]", Name = "Vendors")]
public class VendorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Get(CancellationToken token = new())
    {
        var list = await _mediator.Send(new GetAllVendors.Query(), token);
        return Ok(list);
    }
    
    [HttpGet]
    [Route("{id:int}", Name = nameof(GetVendorById))]
    public async Task<ActionResult> GetById([FromRoute] int id, CancellationToken token = new())
    {
        var entity = await _mediator.Send(new GetVendorById.Query(id), token);
        return Ok(entity);
    }
    
    [HttpPost]
    [Route("", Name = nameof(CreateVendor))]
    public async Task<ActionResult> Post([FromBody]CreateVendor.Command command)
    {
        var entity = await _mediator.Send(command);
        return new CreatedAtRouteResult(nameof(CreateVendor), new { id = entity.Id }, entity);
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody]UpdateVendor.Command command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}