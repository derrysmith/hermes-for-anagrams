namespace Hermes.Api.Core;

/// <summary>
/// 
/// </summary>
public interface IDictionaryService
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="text"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns></returns>
	IEnumerable<string> GetAnagrams(string text, int min, int max);
}