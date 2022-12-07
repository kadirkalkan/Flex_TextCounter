using Base.Api.Application.Interfaces;
using Base.Common.Models.CQRS.Queries.Request.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Base.Api.WebApi.Controllers;

[Route("api/text")]
[ApiController]
public class TextController : ControllerBase
{
    private readonly IMediator _mediator;
    public TextController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ResponseCache(Duration = 3600, VaryByQueryKeys = new string[] { "Url", "CurrentPage", "PageSize" })]
    [HttpGet("get-word-counts")]
    public async Task<IActionResult> GetWordCounts([FromQuery] TextGetWordCountsQueryRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
