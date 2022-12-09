using System.Text.Json;
using Hermes.Core.Anagrams.Services;

namespace Hermes.Data.Anagrams.Services;

/// <inheritdoc />
public class EmbeddedResourceAnagramServiceProvider : IAnagramServiceProvider
{
	/// <inheritdoc />
	public string CreateAnagramKey(string word)
		=> string.Concat(word.OrderBy(c => c));

	/// <inheritdoc />
	public IDictionary<string, IEnumerable<string>> CreateAnagrams()
	{
		var anagrams = new Dictionary<string, IList<string>>();
		
		var dictionaryJson = this.GetEmbeddedJsonDictionary();
		var dictionaryList = JsonSerializer.Deserialize<Dictionary<string, string>>(dictionaryJson);

		if (dictionaryList == null)
			throw new ApplicationException("Could not deserialize JSON dictionary file into a Dictionary<string, string type.");

		foreach (var word in dictionaryList.Keys)
		{
			// create anagram key
			var anagramKey = this.CreateAnagramKey(word);

			if (anagrams.ContainsKey(anagramKey))
				anagrams[anagramKey].Add(word);
			else
				anagrams.Add(anagramKey, new List<string> {word});
		}

		return anagrams.ToDictionary(
			kvp => kvp.Key,
			kvp => kvp.Value.AsEnumerable());
	}

	private string GetEmbeddedJsonDictionary()
	{
		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		var filePath = $"{assembly.GetName().Name}.Json.dictionary.json";

		using var stream = assembly.GetManifestResourceStream(filePath);

		if (stream == null)
			throw new ApplicationException($"Could not get manifest resource stream for {filePath}");
		
		return new StreamReader(stream).ReadToEnd();
	}
}