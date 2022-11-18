namespace Hermes.Words;

/// <inheritdoc />
public class DictionaryService : IDictionaryService
{
	private readonly IDictionaryUtility _utility;
	
	public DictionaryService(IDictionaryUtility utility)
	{
		_utility = utility;
		
		// initialize members
		this.Initialize();
	}
	
	private IDictionary<string, IEnumerable<string>> _anagrams = null!;

	/// <inheritdoc />
	public IEnumerable<string> GetAnagrams(string text, int minLength, int maxLength)
	{
		var anagrams = new List<string>();

		// get all combinations of keys
		var anagramKeys = this.CreateAnagramKeys(text, minLength, maxLength);

		foreach (var anagramKey in anagramKeys)
			if (_anagrams.ContainsKey(anagramKey))
				anagrams.AddRange(_anagrams[anagramKey]);

		// sort by length, then by alpha
		return anagrams.OrderBy(str => str.Length).ThenBy(str => str);
	}

	private void Initialize()
	{
		_anagrams = _utility.CreateAnagramDictionary();
	}

	private IEnumerable<string> CreateAnagramKeys(string text, int min, int max)
	{
		var charactersShiftArray = Enumerable.Range(0, 1 << text.Length);
		var charactersIndexArray = Enumerable.Range(0, text.Length);

		var combinations = charactersShiftArray.Select(i => string.Concat(charactersIndexArray
				.Select(j => (i & (1 << j)) == 0 ? (char?) null : text[j])))
			.Where(str => str.Length >= min && str.Length <= max)
			.Select(_utility.CreateAnagramKey).Distinct();

		return combinations;
	}
}