using System.Text.Json.Serialization;

namespace Hermes.Api.Anagrams.Models;

public record AnagramsApiResponse(
	[property: JsonPropertyName("anagrams")] IEnumerable<string> Anagrams);