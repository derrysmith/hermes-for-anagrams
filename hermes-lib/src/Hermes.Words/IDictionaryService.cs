namespace Hermes.Words;

public interface IDictionaryService
{
	IEnumerable<string> GetAnagrams(string text, int minLength, int maxLength);
}