# hermes

A set of client/server applications to help with word games such as Wordle&reg;, Scrabble&reg;, crossword puzzles, and jumbles.

<!-- badges -->

<!-- overview -->
<!-- install -->

```
> derrysmith/hermes
	> hermes-api
		> src
			> Hermes.Api
			> Hermes.Api.Core
			> Hermes.Api.Data
		> test
			> Hermes.Tests.Api
			> Hermes.Tests.Api.Core
			> Hermes.Tests.Api.Data
	> hermes-cli
		> src
			> Hermes.CLI
			> Hermes.CLI.Core
			> Hermes.CLI.Data
	> client
		> hermes-app
		> hermes-cli
			> src
				> Hermes.CLI
			> test
				> Hermes.CLI.Tests
		> hermes-ext
		> hermes-web
	> server
		> hermes-api
			> src
				> Hermes.Api
			> test
				> Hermes.Api.Tests
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