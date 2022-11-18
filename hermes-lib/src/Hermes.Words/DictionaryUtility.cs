using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Hermes.Words;

/// <inheritdoc />
public class DictionaryUtility : IDictionaryUtility
{
	private readonly ILogger _logger;

	public DictionaryUtility(ILogger<DictionaryUtility> logger)
	{
		_logger = logger;
	}

	/// <inheritdoc />
	public string CreateAnagramKey(string word)
		=> string.Concat(word.OrderBy(c => c));

	/// <inheritdoc />
	public IDictionary<string, IEnumerable<string>> CreateAnagramDictionary()
	{
		// load words from text file
		var dictionaryText = this.GetDictionaryFileText();
		var dictionaryList = dictionaryText.Split("\r\n");

		return this.CreateAnagramDictionary(dictionaryList);
	}

	private string GetDictionaryFileText()
	{
		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		_logger.LogDebug("executing assembly = {FullName}", assembly.FullName);
		var filePath = $"{assembly.GetName().Name}.dictionary.txt";
		_logger.LogDebug("file path to dictionary = {filePath}", filePath);

		using var stream = assembly.GetManifestResourceStream(filePath);
		var reader = new StreamReader(stream!);

		return reader.ReadToEnd();
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