using System.Text.Json.Serialization;
using Hermes.Words;

namespace Hermes.Api.Anagrams.Routes;

public static class GetAnagramsRoute
{
	public record Request(
		string Text,
		int MinLength,
		int MaxLength) : MediatR.IRequest<Response>;

	public record Response(
		[property: JsonIgnore] int Status,
		[property: JsonPropertyName("anagrams")] IEnumerable<string> Anagrams);

	public class Handler : MediatR.RequestHandler<Request, Response>
	{
		private readonly IDictionaryService _service;

		public Handler(IDictionaryService service)
		{
			_service = service;
		}

		protected override Response Handle(Request request)
		{
			var anagrams = _service.GetAnagrams(
				request.Text, request.MinLength, request.MaxLength);

			return new Response(StatusCodes.Status200OK, anagrams);
		}
	}
}