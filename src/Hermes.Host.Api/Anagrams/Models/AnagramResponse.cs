using System.Text.Json.Serialization;

namespace Hermes.Host.Api.Anagrams.Models;

public record AnagramResponse(
	[property: JsonPropertyName("anagrams")]
	IEnumerable<string> Anagrams);