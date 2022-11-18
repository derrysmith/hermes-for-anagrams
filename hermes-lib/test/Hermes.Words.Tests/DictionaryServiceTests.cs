using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Hermes.Words.Tests;

public class DictionaryServiceTests
{
	private ITestOutputHelper _output;

	public DictionaryServiceTests(ITestOutputHelper output)
	{
		_output = output;
	}

	[Fact]
	public void GetAnagrams_returnsAnagrams()
	{
		// arrange
		var text = "loasyuej";
		var utility = new DictionaryUtility();
		var service = new DictionaryService(utility);
		
		// act
		var anagrams = service.GetAnagrams(text, 3, text.Length);
		
		// assert
		foreach (var anagram in anagrams)
			_output.WriteLine(anagram);
	}
}