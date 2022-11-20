namespace Hermes.Api.Core;

/// <summary>
/// 
/// </summary>
public interface IDictionaryServiceProvider
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
	IDictionary<string, IEnumerable<string>> CreateAnagrams();
}