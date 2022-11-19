using System.Text.Json.Serialization;

namespace Hermes.Api.Anagrams.Models;

public record AnagramApiResponse(
	[property: JsonPropertyName("anagrams")] IEnumerable<string> Anagrams);