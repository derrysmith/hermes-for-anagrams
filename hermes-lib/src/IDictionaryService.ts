/**
 * Provides methods for looking up words, their definitions, as well as anagrams, antonyms, and synonyms.
 */
export interface IDictionaryService {
	/**
	 * The current language for this dictionary service instance.
	 */
	language: string;

	/**
	 * Retrieves a collection of anagrams for the given word or set of characters.
	 * @param text the word or characters to find anagrams for
	 * @param min the minimum word-length of anagrams to return
	 * @param max the maximum word-length of anagrams to return
	 */
	getAnagrams(text: string, min: number, max: number): string[];
}