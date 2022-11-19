using Hermes.Api.Anagrams.Models;
using Hermes.Words;
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
	public ActionResult<AnagramApiResponse> GetAnagrams(
		[FromQuery] string text, [FromQuery] int? min, [FromQuery] int? max)
	{
		var minLength = min ?? 3;
		var maxLength = max ?? text.Length;
		var anagrams = _service.GetAnagrams(text, minLength, maxLength);
		
		return this.Ok(new AnagramApiResponse(anagrams));
	}
}