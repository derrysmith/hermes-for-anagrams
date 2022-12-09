using Hermes.Core.Anagrams.Services;
using Hermes.Host.Api.Anagrams.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Host.Api.Anagrams;

[Route("anagrams")]
public class AnagramsController : ControllerBase
{
	private readonly IAnagramService _service;

	public AnagramsController(IAnagramService service)
	{
		_service = service;
	}

	[HttpGet]
	[Produces("application/json")]
	public ActionResult<AnagramResponse> GetAnagrams([FromQuery(Name = "q")] string text, [FromQuery] int? min, [FromQuery] int? max)
	{
		var anagrams = _service.GetAnagrams(text, min ?? 3, max ?? text.Length);
		
		// return 200 OK
		return this.Ok(new AnagramResponse(anagrams));
	}
}