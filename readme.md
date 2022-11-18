# hermes

```
> derrysmith/hermes
	> hermes-api
		> src
			> Hermes.Api
			> Hermes.Api.Tests
	> hermes-app
	> hermes-cli
		> src
			> Hermes.CLI
			> Hermes.CLI.Tests
	> hermes-lib
		> src
			> Hermes.Words
				> Anagrams
					- IAnagramProvider
					- IAnagramProviderFactory
				> Meanings
				> Synonyms
				- IAnagramService
				- IAnagramServiceFactory
				- IAnagramServiceProvider
				- IDictionaryContext
				- IDictionaryService
				- IDictionaryServiceFactory
				- IThesaurusProvider
				- IDictionaryProvider
					.GetAnagrams
					.GetAntonyms
					.GetMeanings
					.GetSynonyms
					.GetThesaurus
					.Get
				- IDictionaryProviderFactory

				- IDictionaryService
					.GetAnagrams (uses IAnagramProvider)
					.GetSynonyms (uses ISynonymProvider)
			> Hermes.Words.Tests
		- hermes-lib.sln
	> hermes-web
```

```sh
$ npm install --save-dev @derrysmith/hermes
```

## hermes-api
## hermes-app
## hermes-cli
## hermes-lib
## hermes-web

`$ hermes anagrams dance --min-length 3 --max-length 5`