using Hermes.Api.Anagrams.Routes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Api.Anagrams;

[Route("anagrams")]
[Produces("application/json")]
public class AnagramsController : ControllerBase
{
	private readonly MediatR.IMediator _mediator;

	public AnagramsController(IMediator mediator)
	{
		_mediator = mediator;
	}

	[HttpGet]
	public async Task<ActionResult<GetAnagramsRoute.Response>> GetAnagrams(
		[FromQuery(Name = "q")] string text,
		[FromQuery(Name = "min")] int? min,
		[FromQuery(Name = "max")] int? max, CancellationToken cancellationToken)
	{
		var getAnagramsRouteRequest = new GetAnagramsRoute.Request(text, min ?? 3, max ?? text.Length);
		var getAnagramsRouteResponse = await _mediator.Send(getAnagramsRouteRequest, cancellationToken);

		return this.StatusCode(getAnagramsRouteResponse.Status, getAnagramsRouteResponse);
	}
}