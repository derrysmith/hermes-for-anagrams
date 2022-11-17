import { readFileSync } from 'fs';
import { join } from 'path';

import { IDictionaryUtility } from "./IDictionaryUtility";

export class DictionaryUtility implements IDictionaryUtility {
	createDictionary(language: string): Map<string, string[]> {
		const filename = `dictionary.${language}.txt`;
		const dictionaryText = readFileSync(join(__dirname, filename), 'utf-8');
		const dictionaryList = dictionaryText.split('\r\n');
		const dictionaryMap = new Map<string, string[]>();

		dictionaryList.forEach(word => {
			dictionaryMap.set(word, []);
		});

		return dictionaryMap;
	}
}
