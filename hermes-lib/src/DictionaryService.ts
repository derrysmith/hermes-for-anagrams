import { inject, injectable } from "tsyringe";
import { IDictionaryService } from "./IDictionaryService";
import { IDictionaryUtility } from "./IDictionaryUtility";
import { types } from "./types";

@injectable()
export class DictionaryService implements IDictionaryService {
	private dictionary: Map<string, string[]>;
	private anagramRecord: Record<string, string[]>;

	constructor(public language: string, @inject(types.IDictionaryUtility) utility: IDictionaryUtility) {
		// load language dictionary
		this.dictionary = utility.createDictionary(language);

		// initialize anagram dictionary
		this.anagramRecord = this.createAnagramRecord();
	}

	public getAnagrams(text: string, min: number, max: number): string[] {
		const anagrams: string[] = [];

		// get all combinations of anagam keys
		const anagramKeys = this.getAnagramKeys(text, min, max);

		anagramKeys.forEach(anagramKey => {
			if (this.anagramRecord.hasOwnProperty(anagramKey)) {
				anagrams.push(...this.anagramRecord[anagramKey]);
			}
		});

		return anagrams.sort((a, b) => {
			// sort by length
			let s = a.length - b.length;

			// then by alpha
			if (s === 0) {
				s = a.localeCompare(b);
			}
			
			return s;
		});
	}

	private createAnagramRecord(): Record<string, string[]> {
		const anagramsByAnagramKey: Record<string, string[]> = {};
		
		for (const word of this.dictionary.keys()) {
			// create anagram key
			const anagramKey = this.createAnagramKey(word);

			// add to or create anagram list
			if (anagramsByAnagramKey.hasOwnProperty(anagramKey)) {
				anagramsByAnagramKey[anagramKey].push(word);
			} else {
				anagramsByAnagramKey[anagramKey] = [word];
			}
		}

		return anagramsByAnagramKey;
	}

	private createAnagramKey(word: string): string {
		return word.split('').sort().join('');
	}

	private getAnagramKeys(text: string, min: number, max: number): string[] {
		const charShiftArray = Array.from(Array(1 << text.length).keys());
		const charIndexArray = Array.from(Array(text.length).keys());

		const allCombinations = charShiftArray.map(i =>
			charIndexArray.map(j => (i & (1 << j)) == 0 ? null : text[j]).join(''))

		// create combination of anagram keys
		.map(str => this.createAnagramKey(str))

		// only return keys that are between min and max
		.filter(s => s.length >= min && s.length <= max);

		// only return distinct values
		const combinations = allCombinations.filter((s, i) => allCombinations.indexOf(s) === i);

		return combinations;
	}
}