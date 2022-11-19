using Hermes.Words;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Hermes.Api.Tests;

public class DependencyTests
{
	[Fact]
	public void CreateAnagramDictionary_returnsAllAnagrams()
	{
		// arrange
		var utility = new DictionaryUtility();
		
		// act
		var actual = utility.CreateAnagramDictionary();
		
		// assert
		Assert.Equal(95053, actual.Keys.Count);
	}

	[Fact]
	public void CreateAnagramKey_returnsAnagramKey()
	{
		// arrange
		var utility = new DictionaryUtility();
		
		// act
		var actual = utility.CreateAnagramKey("dance");
		
		// assert
		Assert.Equal("acden", actual);
	}
}