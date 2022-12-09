namespace Hermes.Core.Anagrams.Services;

/// <summary>
/// 
/// </summary>
public interface IAnagramServiceProvider
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