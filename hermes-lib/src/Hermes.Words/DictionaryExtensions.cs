using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Hermes.Words;

public static class DictionaryExtensions
{
	public static IServiceCollection AddHermes(this IServiceCollection services)
	{
		// IDictionaryService ONCE ONLY
		services.TryAddSingleton<IDictionaryService, DictionaryService>();
		// IDictionaryUtility ONCE ONLY
		services.TryAddSingleton<IDictionaryUtility, DictionaryUtility>();

		return services;
	}
}