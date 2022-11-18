namespace Hermes.Words;

/// <summary>
/// 
/// </summary>
public interface IDictionaryUtility
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="word"></param>
	/// <returns></returns>
	string CreateAnagramKey(string word);

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	IDictionary<string, IEnumerable<string>> CreateAnagramDictionary();
}