namespace Hermes.Api.Core;

/// <inheritdoc />
public class DictionaryService : IDictionaryService
{
	private readonly IDictionaryServiceProvider _provider;
	private readonly IDictionary<string, IEnumerable<string>> _anagrams;

	public DictionaryService(IDictionaryServiceProvider provider)
	{
		_provider = provider;
		
		// initialization of utility members
		_anagrams = _provider.CreateAnagrams();
	}
	
	/// <inheritdoc />
	public IEnumerable<string> GetAnagrams(string text, int min, int max)
	{
		var anagrams = new List<string>();
		
		// get all combination of anagram keys
		var anagramKeys = this.CreateAnagramKeys(text, min, max);

		foreach (var anagramKey in anagramKeys)
		{
			if (_anagrams.ContainsKey(anagramKey))
				anagrams.AddRange(_anagrams[anagramKey]);
		}

		// sort by length, then by alpha
		return anagrams.OrderBy(str => str.Length).ThenBy(str => str);
	}

	private IEnumerable<string> CreateAnagramKeys(string text, int min, int max)
	{
		var charactersShiftArray = Enumerable.Range(0, 1 << text.Length);
		var charactersIndexArray = Enumerable.Range(0, text.Length);

		var combinations = charactersShiftArray.Select(
				i => string.Concat(charactersIndexArray.Select(
					j => (i & (1 << j)) == 0 ? (char?) null : text[j])))
			.Where(str => str.Length >= min && str.Length <= max)
			.Select(_provider.CreateAnagramKey)
			.Distinct();

		return combinations;
	}
}