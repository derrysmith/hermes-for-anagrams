using System.Text.Json;

namespace Hermes.Words;

/// <inheritdoc />
public class DictionaryUtility : IDictionaryUtility
{
	/// <inheritdoc />
	public string CreateAnagramKey(string word)
		=> string.Concat(word.OrderBy(c => c));

	/// <inheritdoc />
	public IDictionary<string, IEnumerable<string>> CreateAnagramDictionary()
	{
		// load words from json file
		var dictionaryJson = this.GetDictionaryFileJson();
		var dictionaryHash = JsonSerializer.Deserialize<Dictionary<string, string>>(dictionaryJson);

		return this.CreateAnagramDictionary(dictionaryHash!.Keys);
	}

	// TODO: find a better json dictionary, some words are missing
	private string GetDictionaryFileJson()
	{
		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		var filePath = $"{assembly.GetName().Name}.dictionary.json";

		using var stream = assembly.GetManifestResourceStream(filePath);

		if (stream == null)
			throw new ApplicationException($"Could not get manifest resource stream for {filePath}");
		
		return new StreamReader(stream).ReadToEnd();
	}

	private IDictionary<string, IEnumerable<string>> CreateAnagramDictionary(IEnumerable<string> dictionary)
	{
		var anagrams = new Dictionary<string, IList<string>>();

		foreach (var word in dictionary)
		{
			// create anagram key
			var anagramKey = this.CreateAnagramKey(word);
			
			// add or create new list of anagrams
			if (anagrams.ContainsKey(anagramKey))
				anagrams[anagramKey].Add(word);
			else
				anagrams.Add(anagramKey, new List<string> {word});
		}

		return anagrams.ToDictionary(
			kvp => kvp.Key,
			kvp => kvp.Value as IEnumerable<string>);
	}
}