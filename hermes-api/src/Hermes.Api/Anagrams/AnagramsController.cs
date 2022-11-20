using Hermes.Api.Anagrams.Models;
using Hermes.Api.Core;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Api.Anagrams;

[Route("anagrams")]
[Produces("application/json")]
public class AnagramsController : ControllerBase
{
	private readonly IDictionaryService _service;

	public AnagramsController(IDictionaryService service)
	{
		_service = service;
	}

	[HttpGet]
	public ActionResult<AnagramsApiResponse> GetAnagrams(
		[FromQuery] string text, [FromQuery] int? min, [FromQuery] int? max)
	{
		var anagrams = _service.GetAnagrams(text, min ?? 3, max ?? text.Length);
		var response = new AnagramsApiResponse(anagrams);

		return this.Ok(response);
	}
}