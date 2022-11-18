using System.Runtime.CompilerServices;
using System.Text;

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
		// load words from text file
		var dictionaryText = this.GetDictionaryFileText();
		var dictionaryList = dictionaryText.Split("\r\n");

		return this.CreateAnagramDictionary(dictionaryList);
	}

	private string GetDictionaryFileText()
	{
		var assembly = System.Reflection.Assembly.GetExecutingAssembly();
		var filePath = $"{assembly.GetName().Name}.dictionary.txt";

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